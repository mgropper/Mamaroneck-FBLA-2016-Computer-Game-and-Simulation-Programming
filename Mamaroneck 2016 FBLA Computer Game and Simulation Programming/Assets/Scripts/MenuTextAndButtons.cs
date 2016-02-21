using UnityEngine;
using System.Collections;

public class MenuTextAndButtons : MonoBehaviour {
    public bool guiMenuEnabled = true;
	public Texture buttonPlayTexture;
	public Texture buttonQuitTexture;
	public Texture buttonBackTexture;
	public GUIStyle textStyle;
	public GUIStyle rectStyle;
    public GUIStyle buttonStyle;
	public Font font;
    void start(){

    }

	void OnGUI () {
		GUI.Label(new Rect(0, 0, Screen.width, 250), "Nightmares:\nThe Mamaroneck FBLA\n2016 Computer Game and Simulation Programming Submission", textStyle); //create text at top with game name
        if (guiMenuEnabled) {
			if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height/2 - 25, 200, 125), buttonPlayTexture, rectStyle)) { //create button to play game
				guiMenuEnabled = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height/2 - 25, 200, 125), buttonQuitTexture, rectStyle)) { //create button to quit game
				Application.Quit ();
			}
		} else {
			if (GUI.Button(new Rect(50, Screen.height / 2 - 75, 150, 125), "Level 0", buttonStyle))
			{ //create button to load level one
				Application.LoadLevel("Level0");
			}
			if (GUI.Button(new Rect(225, Screen.height / 2 - 75, 150, 125), "Level 1", buttonStyle))
            { //create button to load level one
                Application.LoadLevel("level1");
            }
			if (GUI.Button(new Rect(400, Screen.height / 2 - 75, 150, 125), "Level 2", buttonStyle))
            { //create button to load level 2
                Application.LoadLevel("level2");
            }
			if (GUI.Button(new Rect(575, Screen.height / 2 - 75, 150, 125), "Level 3", buttonStyle))
            { //create button to load level 3
                Application.LoadLevel("level3");
            }
			if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height - 200, 200, 125), buttonBackTexture, rectStyle)) { //create button to play game
				guiMenuEnabled = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height - 200, 200, 125), buttonQuitTexture, rectStyle)) { //create button to quit game
				Application.Quit ();
			}
        }
	}
}
