using UnityEngine;
using System.Collections;

public class slider : MonoBehaviour {
	public float max;
	public float min;
	public float speed;
	public GameObject platform;
	private bool right;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			platform.transform.position = new Vector3 (platform.transform.position.x + speed, platform.transform.position.y);
			if(platform.transform.position.x >= max){
				right = false;
			}
		}else{
			platform.transform.position = new Vector3 (platform.transform.position.x - speed, platform.transform.position.y);
			if(platform.transform.position.x <= min){
				right = true;
			}
		}
	}
}
