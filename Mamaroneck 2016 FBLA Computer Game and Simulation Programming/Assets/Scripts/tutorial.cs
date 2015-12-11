using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {
    public GameObject tutCam;
    public GUIStyle image;
    public GUIStyle text;
    bool tut = true;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI() {
        if (tut){
            GUI.Label(new Rect(Screen.width/2 - 125, 200, 200, 125), "The objective of every level is to suit up. \nIn order to suit up, you must retrieve the jacket, tie, shoes and pants.\nOne of these can found at the end of each path.\nHowever, if you fall, you must start over again", text);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 175), "", image)) {
                Application.LoadLevel(2);
            }
        }
    }
}
