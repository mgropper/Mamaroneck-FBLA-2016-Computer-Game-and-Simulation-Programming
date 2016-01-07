using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform origin;
    public GameObject player;
    string area = "middle";
    public bool topLeft = false;
    public bool topRight = false;
    public bool bottomLeft = false;
    public bool bottomRight = false;
    public bool middle = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.y < -2 && (area.Equals("topLeft") || area.Equals("topRight")))
        {
            player.transform.position = origin.transform.position;
        }else if (player.transform.position.y < -10 && (area.Equals("bottomLeft") || area.Equals("bottomRight") || area.Equals("middle")))
        {
            player.transform.position = origin.position;
        }




    }

    void OnTriggerEnter2D()
    {
        if (topLeft)
        {
            area = "topLeft";
            origin.position = new Vector3(-3.7f, 3.1f);
        }else if (topRight)
        {
            area = "topRight";
            origin.position = new Vector3(5.3f, 3.1f);
        }
        else if (middle)
        {
            area = "middle";
            origin.position = new Vector3(1.3f, 1.1f);
        }
        else if (bottomLeft)
        {
            area = "bottomLeft";
            origin.position = new Vector3(-3.7f, -0.9f);
        }
        else if (bottomRight)
        {
            area = "bottomRight";
            origin.position = new Vector3(5.3f, -0.9f);
        }
    }
}
