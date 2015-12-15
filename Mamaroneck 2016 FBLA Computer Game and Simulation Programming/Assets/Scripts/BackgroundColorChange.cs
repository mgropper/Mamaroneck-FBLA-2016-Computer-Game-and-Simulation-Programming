using UnityEngine;
using System.Collections;
/**
 * Sets the Background color to a random color
 **/
public class BackgroundColorChange : MonoBehaviour {
	public Camera Gamecamera;
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
            Gamecamera.backgroundColor = zero;
        } else if (rand == 1) {
            Gamecamera.backgroundColor = one;
        } else if (rand == 2) {
            Gamecamera.backgroundColor = two;
        } else if (rand == 3) {
            Gamecamera.backgroundColor = three;
        } else if (rand == 4) {
            Gamecamera.backgroundColor = four;
        } else if (rand == 5) {
            Gamecamera.backgroundColor = five;
        }
	}
}
