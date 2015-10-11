using UnityEngine;
using System.Collections;
/**
 * 
 * */
public class MenuTextAndButtons : MonoBehaviour {
	bool guiMenuEnabled = true;
	public string gameName;
	public Texture buttonPlayTexture;
	public Texture buttonQuitTexture;
	public GUIStyle textStyle;
	public GUIStyle rectStyle;

	void OnGUI () {
		if (guiMenuEnabled) {
			if (GUI.Button (new Rect (Screen.width / 2 - 225, Screen.height - 200, 200, 125), buttonPlayTexture, rectStyle)) { //create button to play game
				guiMenuEnabled = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 25, Screen.height - 200, 200, 125), buttonQuitTexture, rectStyle)) { //create button to quit game
				Application.Quit ();
			}
			GUI.Label (new Rect (Screen.width / 2 - 100, 30, 250, 250), gameName, textStyle); //create text at top with game name
		} else {

		}
	}
}
