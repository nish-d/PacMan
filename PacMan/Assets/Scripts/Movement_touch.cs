using UnityEngine;
using System.Collections;

public class Movement_touch : MonoBehaviour {
	
	public float mouseX, mouseY;
	public Vector3 worldPos;
	public int x=0;
	public float speed = 2;

	public int eaten = 0;
	public static int highscore;
	public TextMesh score;

	//audioclips
	public AudioClip eatme;
	private AudioSource source;

	public bool touching = false;
	// Use this for initialization


	void Start () {
		source = GetComponent<AudioSource> ();
		Screen.SetResolution(217, 316, true);
	}

	// Update is called once per frame
	void Update () {
		if (!touching) {
			switch (x) {
			case 1:
				transform.position += Vector3.up * speed;
				break;
			case 2:
				transform.position += Vector3.down * speed;
				break;
			case 3:
				transform.position += Vector3.right * speed;
				break;
			case 4:
				transform.position += Vector3.left * speed;
				break;
			}
			if (Input.GetMouseButtonDown (0)) {
				touching = false;
				mouseX = Input.mousePosition.x;
				mouseY = Input.mousePosition.y;
				worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				x = getdiff (worldPos.x, worldPos.y, transform.position); 	
			}

		}
	}
	public int getdiff(float x, float y, Vector3 position){
		float diffx, diffy;
		diffx = x - position.x;
		diffy = y - position.y;
		if (Mathf.Abs (diffx) > Mathf.Abs (diffy) && diffx > 0)
			return 3;
		else if (Mathf.Abs (diffx) > Mathf.Abs (diffy) && diffx < 0)
			return 4;
		else if (Mathf.Abs (diffy) > Mathf.Abs (diffx) && diffy < 0)
			return 2;
		else
			return 1;
	}


	void OnTriggerEnter2D(Collider2D y){
		if (y.gameObject.tag == "bounds") {
			switch (x) {
			case 1:
				down ();
				break;
			case 2:
				up ();
				break;
			case 3:
				left ();
				break;
			case 4:
				right ();
				break;
			}
		}
			if (y.gameObject.tag == "eat") {
				Destroy (y.gameObject);
				eaten += 1;
				score.text = eaten.ToString ();

			source.PlayOneShot (eatme);
			if (highscore < eaten)
				highscore = eaten;
			}

	}
	void OnTriggerExit2D(Collider2D y){
		if (y.transform.position.x > transform.position.x)
		touching = false;
	}

	void left()
	{transform.position += Vector3.left * 25;
		
	}
	void right()
	{transform.position += Vector3.right * 25;
		
	}
	void up(){
		
		transform.position += Vector3.up * 25;
	}
	void down(){
		
		transform.position += Vector3.down * 25;
	}
		
}
