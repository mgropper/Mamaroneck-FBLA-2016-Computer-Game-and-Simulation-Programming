using UnityEngine;
using System.Collections;

public class platformDisappear : MonoBehaviour {
    public GameObject topRight;
    public GameObject topLeft;
    public GameObject bottomRight;
    public GameObject bottomLeft;
    public GameObject middle;
    public GameObject topRightArrow;
    public GameObject topLeftArrow;
    public GameObject bottomRightArrow;
    public GameObject bottomLeftArrow;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter() {
        Debug.Log("true");
        if(transform.localPosition == topRight.transform.position)
        {
            topLeft.SetActive(false);
            bottomRight.SetActive(false);
            bottomLeft.SetActive(false);
            topRightArrow.SetActive(false);
            bottomRightArrow.SetActive(false);
            bottomLeftArrow.SetActive(false);
        }
    }
}
