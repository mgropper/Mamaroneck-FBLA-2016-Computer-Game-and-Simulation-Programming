using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform origin;
    public GameObject player;
    public bool checkpoint = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.transform.position.y < 0 && player.transform.position.y <= -7) {
            player.transform.position = origin.position;
        } if (player.transform.position.y > 0 && player.transform.position.y < 0) {
            player.transform.position = origin.position;
        }
	}

    void OnTriggerEnter() {
        if (checkpoint) {
            origin.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + 2);
        }
    }
}
