using UnityEngine;
using System.Collections;

public class celebratoryConclusion : MonoBehaviour {
	public Texture buttonPlayTexture;
	public Texture buttonQuitTexture;
	public GUIStyle rectStyle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height/2 - 25, 200, 125), buttonPlayTexture, rectStyle)) { //create button to play game
			Application.LoadLevel(0);
		}
		if (GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height/2 - 25, 200, 125), buttonQuitTexture, rectStyle)) { //create button to quit game
			Application.Quit ();
		}
	}
}
