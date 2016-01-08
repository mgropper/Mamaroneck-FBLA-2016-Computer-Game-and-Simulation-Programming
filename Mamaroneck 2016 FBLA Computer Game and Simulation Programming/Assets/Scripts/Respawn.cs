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
    public GameObject topLeftG;
    public GameObject topRightG;
    public GameObject bottomLeftG;
    public GameObject bottomRightG;
    public GameObject middleG;
    public GameObject arrows;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if((area.Equals("topLeft") || area.Equals("topRight")) && player.transform.position.y < -6)
        {
            player.transform.position = origin.transform.position;
        }else if ((area.Equals("bottomLeft") || area.Equals("bottomRight") || area.Equals("middle")) && player.transform.position.y < -10)
        {
            player.transform.position = origin.position;
        }




    }

    void OnTriggerEnter2D()
    {
        if (topLeft)
        {
            area = "topLeft";
            origin.position = new Vector3(-2.7f, 3.1f);
            arrows.SetActive(false);
            topLeftG.SetActive(true);
            topRightG.SetActive(false); 
            bottomLeftG.SetActive(false);
            bottomRightG.SetActive(false);
            middleG.SetActive(false);
        }
        else if (topRight)
        {
            area = "topRight";
            origin.position = new Vector3(5.3f, 3.1f);
            arrows.SetActive(false);
            topLeftG.SetActive(false);
            topRightG.SetActive(true);
            bottomLeftG.SetActive(false);
            bottomRightG.SetActive(false);
            middleG.SetActive(false);
        }
        else if (middle)
        {
            area = "middle";
            origin.position = new Vector3(1.3f, 1.1f);
            topLeftG.SetActive(true);
            topRightG.SetActive(true);
            bottomLeftG.SetActive(true);
            bottomRightG.SetActive(true);
            middleG.SetActive(true);
        }
        else if (bottomLeft)
        {
            area = "bottomLeft";
            origin.position = new Vector3(-2.7f, -0.9f);
            arrows.SetActive(false);
            topLeftG.SetActive(false);
            topRightG.SetActive(false);
            bottomLeftG.SetActive(true);
            bottomRightG.SetActive(false);
            middleG.SetActive(false);
        }
        else if (bottomRight)
        {
            area = "bottomRight";
            origin.position = new Vector3(5.3f, -0.9f);
            arrows.SetActive(false);
            topLeftG.SetActive(false);
            topRightG.SetActive(false);
            bottomLeftG.SetActive(false);
            bottomRightG.SetActive(true);
            middleG.SetActive(false);

        }
    }
}

