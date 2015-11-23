using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform low;
    public Transform origin;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.localPosition.y <= low.position.y) {
            transform.localPosition = origin.position;
        }
	}
}
