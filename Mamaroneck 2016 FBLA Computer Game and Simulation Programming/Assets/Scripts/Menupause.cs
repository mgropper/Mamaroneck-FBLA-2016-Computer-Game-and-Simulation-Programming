using UnityEngine;
using System.Collections;

public class Menupause : MonoBehaviour {
	public Font pauseMenuFont;
	public GameObject cc;
	private bool pauseEnabled = false;
	private bool showGraphicsDropDown = false;
	private bool back = false;
	public GUIStyle pauseButton;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape") || back){		
			if(pauseEnabled == true){
				pauseEnabled = false;
				back = false;
				slider.able = true;
				elevator.able = true;
				Cursor.visible = false;
				GameObject.Find("character").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}else if(pauseEnabled == false){
				pauseEnabled = true;
				Cursor.visible = true;
				slider.able = false;
				elevator.able = false;
				GameObject.Find("character").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
	}

	void OnGUI(){
		if (!pauseEnabled) {
			if (GUI.Button (new Rect (10, 10, 50, 50), "", pauseButton)) {
				pauseEnabled = true;
				Cursor.visible = true;
				slider.able = false;
				elevator.able = false;
				GameObject.Find("character").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		Cursor.visible = true;
		if(pauseEnabled == true){
			GUI.Box(new Rect(Screen.width /2 - 100,Screen.height /2 - 150,250,250), "Pause Menu");
			if(GUI.Button(new Rect(Screen.width /2 - 100,Screen.height /2 - 100,250,50), "Main Menu")){
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(Screen.width /2 - 100,Screen.height /2 - 50,250,50), "Change Quality Settings")){
				if(showGraphicsDropDown == false){
					showGraphicsDropDown = true;
				}
				else{
					showGraphicsDropDown = false;
				}
			}
			if(showGraphicsDropDown == true){
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 - 50,250,50), "Fastest")){
					QualitySettings.SetQualityLevel(0);
					showGraphicsDropDown = false;
					back = true;		
				}
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2,250,50), "Fast")){
					QualitySettings.SetQualityLevel(1);
					showGraphicsDropDown = false;
					back = true;	
				}
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 50,250,50), "Simple")){
					QualitySettings.SetQualityLevel(2);
					showGraphicsDropDown = false;
					back = true;	
				}
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 100,250,50), "Good")){
					QualitySettings.SetQualityLevel(3);
					showGraphicsDropDown = false;
					back = true;	
				}
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 150,250,50), "Beautiful")){
					QualitySettings.SetQualityLevel(4);
					showGraphicsDropDown = false;
					back = true;	
				}
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 200,250,50), "Fantastic")){
					QualitySettings.SetQualityLevel(5);
					showGraphicsDropDown = false;
					back = true;	
				}
				
				if(Input.GetKeyDown("escape")){
					showGraphicsDropDown = false;
					pauseEnabled = false;
				}
			}
			if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2,250,50), "Quit Game")){
				Application.Quit();
			}
			if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Back")){
				pauseEnabled = false;
				back = false;
				slider.able = true;
				elevator.able = true;
				Cursor.visible = false;	
				GameObject.Find("character").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}
			
		}
	}
}