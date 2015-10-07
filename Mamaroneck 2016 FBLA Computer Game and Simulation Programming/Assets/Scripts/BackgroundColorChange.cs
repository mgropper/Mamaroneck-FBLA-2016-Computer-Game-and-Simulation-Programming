using UnityEngine;
using System.Collections;
/**
 * Sets the Background color to a random color
 **/
public class BackgroundColorChange : MonoBehaviour {
	public Camera camera;
	public Color zero = Color.red;
	public Color one = Color.red;
	public Color two = Color.red;
	public Color three = Color.red;
	public Color four = Color.red;
	public Color five = Color.red;
	// Use this for initialization
	void Start () {
		int rand = (int)(Random.value * 10) / 2;
		Debug.Log (rand); //shows value to console
		if (rand == 0) {
			camera.backgroundColor = zero;
		} else if (rand == 1) {
			camera.backgroundColor = one;
		} else if (rand == 2) {
			camera.backgroundColor = two;
		} else if (rand == 3) {
			camera.backgroundColor = three;
		} else if (rand == 4) {
			camera.backgroundColor = four;
		} else if (rand == 5) {
			camera.backgroundColor = five;
		}
	}
}
