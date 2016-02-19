using UnityEngine;
using System.Collections;

public class Menupause : MonoBehaviour
{
	public Font pauseMenuFont;
	public static bool pauseEnabled = false;
	private bool showGraphicsDropDown = false;
	private bool back = false;
	public GUIStyle pauseButton;
	public Texture backT;
	public Texture mainMenuT;
	public Texture settingsT;
	public Texture restartT;
	public Texture quitT;
	public GUIStyle buttonStyle;


	// Use this for initialization
	void Start ()
	{
		pauseEnabled = false;
		back = false;
		slider.able = true;
		elevator.able = true;
		PlatformerCharacter2D.ableFlip = true;
		gameMechanics.record = false;
		gameMechanics.scoreMenu = false;
		GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Input.GetKeyDown ("escape") || back) && !gameMechanics.scoreMenu) {		
			if (pauseEnabled == true) {
				pauseEnabled = false;
				back = false;
				slider.able = true;
				elevator.able = true;
				PlatformerCharacter2D.ableFlip = true;
				gameMechanics.record = true;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			} else if (pauseEnabled == false) {
				pauseEnabled = true;
				slider.able = false;
				elevator.able = false;
				PlatformerCharacter2D.ableFlip = false;
				gameMechanics.record = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
	}

	void OnGUI ()
	{
		if (!gameMechanics.scoreMenu) {
			if (GUI.Button (new Rect (10, 10, 50, 50), "", pauseButton)) {
				pauseEnabled = true;
				slider.able = false;
				elevator.able = false;
				gameMechanics.record = false;
				PlatformerCharacter2D.ableFlip = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		Cursor.visible = true;
		if (pauseEnabled == true) {
			GUI.Box (new Rect (400, Screen.height / 2 - 190, 500, 100), "Game Paused");
			if (GUI.Button (new Rect (525, Screen.height / 2 - 150, 50, 50), mainMenuT, buttonStyle)) {
				Application.LoadLevel (0);
			}
			if (GUI.Button (new Rect (625, Screen.height / 2 - 150, 50, 50), settingsT, buttonStyle)) {
				if (showGraphicsDropDown == false) {
					showGraphicsDropDown = true;
				} else {
					showGraphicsDropDown = false;
				}
			}
			if (showGraphicsDropDown == true) {
				GUI.Box (new Rect (525, Screen.height / 2 - 90, 250, 350), "Quality Settings");
				if (GUI.Button (new Rect (525, Screen.height / 2 - 40, 250, 50), "Fastest")) {
					QualitySettings.SetQualityLevel (0);
					showGraphicsDropDown = false;
					back = true;		
				}
				if (GUI.Button (new Rect (525, Screen.height / 2 + 10, 250, 50), "Fast")) {
					QualitySettings.SetQualityLevel (1);
					showGraphicsDropDown = false;
					back = true;	
				}
				if (GUI.Button (new Rect (525, Screen.height / 2 + 60, 250, 50), "Simple")) {
					QualitySettings.SetQualityLevel (2);
					showGraphicsDropDown = false;
					back = true;	
				}
				if (GUI.Button (new Rect (525, Screen.height / 2 + 110, 250, 50), "Good")) {
					QualitySettings.SetQualityLevel (3);
					showGraphicsDropDown = false;
					back = true;	
				}
				if (GUI.Button (new Rect (525, Screen.height / 2 + 160, 250, 50), "Beautiful")) {
					QualitySettings.SetQualityLevel (4);
					showGraphicsDropDown = false;
					back = true;	
				}
				if (GUI.Button (new Rect (525, Screen.height / 2 + 210, 250, 50), "Fantastic")) {
					QualitySettings.SetQualityLevel (5);
					showGraphicsDropDown = false;
					back = true;	
				}
			}
			if (GUI.Button (new Rect (725, Screen.height / 2 - 150, 50, 50), restartT, buttonStyle)) {
				Application.LoadLevel (Application.loadedLevel);
			}
			if (GUI.Button (new Rect (825, Screen.height / 2 - 	150, 50, 50), quitT, buttonStyle)) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (425, Screen.height / 2 - 	150, 50, 50), backT, buttonStyle)) {
				pauseEnabled = false;
				back = false;
				slider.able = true;
				elevator.able = true;	
				gameMechanics.record = true;
				PlatformerCharacter2D.ableFlip = true;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}
			
		}
	}
}