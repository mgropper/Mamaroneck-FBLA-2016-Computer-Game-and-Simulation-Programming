using UnityEngine;
using System.Collections;
/**
 * 
 * */
public class MenuTextAndButtons : MonoBehaviour {
    public GameObject playerFake;
    bool guiMenuEnabled = true;
	public string gameName;
	public Texture buttonPlayTexture;
	public Texture buttonQuitTexture;
	public GUIStyle textStyle;
	public GUIStyle rectStyle;
    public GUIStyle buttonStyle;
    public Animator anim;

    void start(){
        anim.SetBool("isMenu", true);
    }

	void OnGUI () {
        GUI.Label(new Rect(-20, 30, Screen.width, 250), gameName, textStyle); //create text at top with game name
        if (guiMenuEnabled) {
			if (GUI.Button (new Rect (Screen.width / 2 - 225, Screen.height - 200, 200, 125), buttonPlayTexture, rectStyle)) { //create button to play game
				guiMenuEnabled = false;
                playerFake.SetActive(false);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 25, Screen.height - 200, 200, 125), buttonQuitTexture, rectStyle)) { //create button to quit game
				Application.Quit ();
			}
		} else {
            if (GUI.Button(new Rect(Screen.width / 2 - 500, Screen.height / 2, 200, 125), "1", buttonStyle))
            { //create button to load level one
                Application.LoadLevel(1);
            }
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 125), "2", buttonStyle))
            { //create button to load level 2
                Application.LoadLevel(2);
            }
			if (GUI.Button(new Rect(Screen.width / 2 + 300, Screen.height / 2, 200, 125), "3", buttonStyle))
            { //create button to load level 3
                Application.LoadLevel(3);
            }
        }
	}
}
