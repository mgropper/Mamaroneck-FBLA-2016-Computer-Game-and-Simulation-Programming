using UnityEngine;
using System.Collections;

public class Menupause : MonoBehaviour {
	private bool inMenu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if(inMenu){
				slider.setAble(false);
				elevator.setAble(false);
			}else{
				slider.setAble(true);
				elevator.setAble(true);
			}
		}
	}
}
