using UnityEngine;
using System.Collections;

public class gameMechanics : MonoBehaviour {
    public GameObject player;
    public bool topLeft = false;
    public bool topRight = false;
    public bool bottomLeft = false;
    public bool bottomRight = false;
    public bool middle = true;
    public bool piece = false;
    public bool hasObject = true;
    public GameObject topLeftG;
    public GameObject topRightG;
    public GameObject bottomLeftG;
    public GameObject bottomRightG;
    public GameObject middleG;
    public GameObject pieceG;
    public Sprite pants;
    public Sprite tie;
    public Sprite jacket;
    public Sprite shoes;

    // Use this for initialization
    void Start () {
        middleG.SetActive(true);
        topRightG.SetActive(true);
        topLeftG.SetActive(false);
        bottomRightG.SetActive(false);
        bottomLeftG.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        if (middle)
        {
            if (hasObject && topRight)
            {
                topLeftG.SetActive(false);
                topRightG.SetActive(false);
                bottomLeftG.SetActive(false);
                bottomRightG.SetActive(true);
            }
            else if (hasObject && topLeft)
            {
                topLeftG.SetActive(false);
                topRightG.SetActive(false);
                bottomLeftG.SetActive(true);
                bottomRightG.SetActive(false);
            }
            else if (hasObject && bottomLeft)
            {
                Application.LoadLevel(2);
            }
            else if (hasObject && bottomRight)
            {
                {
                    topLeftG.SetActive(true);
                    topRightG.SetActive(false);
                    bottomLeftG.SetActive(false);
                    bottomRightG.SetActive(false);
                }
            }
        }
        else if (topRight)
        {
            middleG.SetActive(false);
            if (hasObject)
            {
                middleG.SetActive(true);
                player.GetComponent<SpriteRenderer>().sprite = pants;
            }
        }
        else if (topLeft)
        {
            middleG.SetActive(false);
            if (hasObject)
            {
                middleG.SetActive(true);
                player.GetComponent<SpriteRenderer>().sprite = jacket;
            }
        }
        else if (bottomLeft)
        {

            middleG.SetActive(false);
            if (hasObject)
            {
                middleG.SetActive(true);
                player.GetComponent<SpriteRenderer>().sprite = tie;
            }
        }
        else if (bottomRight)
        {
            middleG.SetActive(false);
            if (hasObject)
            {
                middleG.SetActive(true);
                player.GetComponent<SpriteRenderer>().sprite = shoes;
            }

        }
        else if (piece)
        {
            hasObject = true;

        }
    }
}
