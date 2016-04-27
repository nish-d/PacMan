using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

	public Transform[] waypoints;
	int cur=0;
	private float speed=5f;
	public static int lives;
	public TextMesh life;
	// Use this for initialization
	void Start () {
		if (life.text == "3")
			lives = 3;
		else if (life.text == "2")
			lives = 2;
		else if (life.text == "1")
			lives = 1;
		else
			lives = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position != waypoints[cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
				waypoints[cur].position,
				speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else cur = (cur + 1) % waypoints.Length;
	}
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman_0") {
			//Destroy (co.gameObject);
			lives--;
			life.text = lives.ToString ();
			if (lives == 0)
				Application.LoadLevel ("Menu");
			else {
				co.gameObject.transform.position = new Vector3 (1075.0f, 777.0f, 1501.0f);
				//transform.position = waypoints [0].position;
			}
		}
	}
}
