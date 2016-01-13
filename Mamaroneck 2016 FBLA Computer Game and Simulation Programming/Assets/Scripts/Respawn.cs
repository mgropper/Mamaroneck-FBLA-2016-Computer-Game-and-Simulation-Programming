using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Transform origin;
    public GameObject player;
    public bool topLeft = false;
    public bool topRight = false;
    public bool bottomLeft = false;
    public bool bottomRight = false;
    public bool middle = true;
    public GameObject topLeftG;
    public GameObject topRightG;
    public GameObject bottomLeftG;
    public GameObject bottomRightG;
    public GameObject middleG;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if((topLeft || topRight) && player.transform.position.y < -6)
        {
            player.transform.position = origin.transform.position;
        }else if ((bottomLeft || bottomRight || middle) && player.transform.position.y < -10)
        {
            player.transform.position = origin.position;
        }




    }

    void OnTriggerEnter2D()
    {
        if (topLeft)
        {
            origin.position = new Vector3(-2.7f, 3.1f);
        }
        else if (topRight)
        {
            origin.position = new Vector3(5.3f, 3.1f);
        }
        else if (middle)
        {
            origin.position = new Vector3(1.3f, 1.1f);
        }
        else if (bottomLeft)
        {
            origin.position = new Vector3(-2.7f, -0.9f);
        }
        else if (bottomRight)
        {
            origin.position = new Vector3(5.3f, -0.9f);

        }
    }
}

