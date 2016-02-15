using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour
{
	public float max;
	public float min;
	public float speed;
	public GameObject platform;
	private bool up;
	public static bool able = true;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (able) {
			if (up) {
				platform.transform.position = new Vector3 (platform.transform.position.x, platform.transform.position.y + speed);
				if (platform.transform.position.y >= max) {
					up = false;
				}
			} else {
				platform.transform.position = new Vector3 (platform.transform.position.x, platform.transform.position.y - speed);
				if (platform.transform.position.y <= min) {
					up = true;
				}
			}
		}
	}
}
