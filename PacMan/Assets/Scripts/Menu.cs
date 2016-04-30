using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Start () {
		//Screen.SetResolution (183, 326, true);
		score.text = Movement_touch.highscore.ToString ();
		Screen.SetResolution(217, 316, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play_btn()
	{
		Application.LoadLevel ("GameScene");
	}

	public void quit_btn()
	{
		Application.Quit ();	
	}
}
