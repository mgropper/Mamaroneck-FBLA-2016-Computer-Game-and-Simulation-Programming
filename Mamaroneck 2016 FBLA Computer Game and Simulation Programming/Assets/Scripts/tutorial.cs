using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {
	private bool pauseRety = true;
	public GUIStyle nextButton;


    // Use this for initialization
    void Start () {
		slider.able = false;
		elevator.able = false;
		PlatformerCharacter2D.ableFlip = false;
		gameMechanics.record = false;
		GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI() {
        if (pauseRety) {
			if(GUI.Button(new Rect(Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)){
				pauseRety = false;
			}
		}
    }
}
