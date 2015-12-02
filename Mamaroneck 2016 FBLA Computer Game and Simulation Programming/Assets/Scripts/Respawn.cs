using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform low;
    public Transform origin;
    public GameObject player;
    public bool checkpoint = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.transform.position.y <= low.position.y) {
            transform.localPosition = origin.position;
        }
	}

    void OnTriggerEnter(Collider other) {
        low.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - 1);
        if (checkpoint) {
            origin.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + (float) 0.5);
        }
    }
}
