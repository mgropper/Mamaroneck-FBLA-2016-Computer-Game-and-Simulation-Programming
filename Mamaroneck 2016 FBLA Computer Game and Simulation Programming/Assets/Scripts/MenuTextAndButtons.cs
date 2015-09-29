using UnityEngine;
using System.Collections;

public class MenuTextAndButtons : MonoBehaviour {
	public string gameName;
	public Texture buttonPlayTexture;
	public Texture buttonQuitTexture;
	public GUIStyle style;
	 
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height - 300, 200, 125), buttonPlayTexture)) { //create button to play game
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height - 150, 200, 125), buttonQuitTexture)) { //create button to play game
			Application.Quit();
		}
		GUI.Label (new Rect (Screen.width / 2, 30, 250, 250), gameName, style); //create text at top with game name
	}
}
