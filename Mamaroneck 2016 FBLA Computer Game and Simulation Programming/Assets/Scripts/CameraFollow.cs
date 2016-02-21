using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Camera main;
	public GameObject character;

	// Use this for initialization
	void Start () {
		main.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - .3f, (float) -0.5);
	}
	
	// Update is called once per frame
	void Update () {
		main.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - .3f, (float) -0.5);
	}
}
