using UnityEngine;
using System.Collections;

public class Movement_touch : MonoBehaviour {
	public float mouseX, mouseY;
	public int x=0;
	public float speed = 2;
	public Vector3 worldPos;
	public int eaten = 0;
	public static int highscore;
	public int first = 0;
	public bool gameOver = false;
	public bool touching = false;
	// Use this for initialization
	public TextMesh score;
	//public TextMesh life;
	void Start () {
		//print (transform.position);
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
			Vector3 collisionPos = y.bounds.center;
			if (x == 3 || x == 4) {

				if (collisionPos.x > transform.position.x) {
					//print (" collider to the right");
					left ();
				} else if (collisionPos.x < transform.position.x) {
					//print ("collider to the left");
					right ();
				} 
			} else {
				if (collisionPos.y > transform.position.y) {
					down ();
					//print ("collider to the top");
				} else {
					up ();
					//print ("collider to the bottom");
				}
			}
		}
			if (y.gameObject.tag == "eat") {
				Destroy (y.gameObject);
				eaten += 1;
				score.text = eaten.ToString ();
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
		//print ("left");
	}
	void right()
	{transform.position += Vector3.right * 25;
		//print ("right");
	}
	void up(){
		//print ("up");
		transform.position += Vector3.up * 25;
	}
	void down(){
		//print ("down");
		transform.position += Vector3.down * 25;
	}
		
}
