using UnityEngine;
using System.Collections;

public class gameMechanics : MonoBehaviour
{
    public Transform origin;
    public GameObject player;
    public bool topLeft = false;
    public bool topRight = false;
    public bool bottomLeft = false;
    public bool bottomRight = false;
    public bool middle = false;
    public bool piece = false;
    public bool hasObject = false;
    public GameObject topLeftG;
    public GameObject topRightG;
    public GameObject bottomLeftG;
    public GameObject bottomRightG;
    public GameObject middleG;
    public GameObject pieceG;
    public Sprite orig;
    public Sprite pants;
    public Sprite tie;
    public Sprite jacket;
    public Sprite shoes;

    // Use this for initialization
    void Start()
    {
        middleG.SetActive(true);
        topRightG.SetActive(true);
        topLeftG.SetActive(false);
        bottomRightG.SetActive(false);
        bottomLeftG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((topLeft || topRight) && player.transform.position.y < -6)
        {
            player.transform.position = origin.transform.position;
            pieceG.SetActive(true);
            if (topLeft)
            {
                player.GetComponent<SpriteRenderer>().sprite = tie;
            }
            else if (topRight)
            {
                player.GetComponent<SpriteRenderer>().sprite = orig;
            }
            middleG.SetActive(false);
        }
        else if ((bottomLeft || bottomRight || middle) && player.transform.position.y < -10)
        {
            player.transform.position = origin.position;
            pieceG.SetActive(true);
            if (bottomLeft)
            {
                player.GetComponent<SpriteRenderer>().sprite = jacket;
            }
            else if (bottomRight)
            {
                player.GetComponent<SpriteRenderer>().sprite = pants;
            }
            middleG.SetActive(false);
        }




    }

    void OnTriggerEnter2D()
    {
        if (middle)
        {
            origin.position = new Vector3(1.3f, 1.1f);
            if (hasObject && topRight && !piece)
            {
                topLeftG.SetActive(false);
                topRightG.SetActive(false);
                bottomLeftG.SetActive(false);
                bottomRightG.SetActive(true);
            }
            else if (hasObject && topLeft && !piece)
            {
                topLeftG.SetActive(false);
                topRightG.SetActive(false);
                bottomLeftG.SetActive(true);
                bottomRightG.SetActive(false);
            }
            else if (hasObject && bottomLeft && !piece)
            {
                Application.LoadLevel(2);
            }
            else if (hasObject && bottomRight && !piece)
            {

                topLeftG.SetActive(true);
                topRightG.SetActive(false);
                bottomLeftG.SetActive(false);
                bottomRightG.SetActive(false);
            }
        }
        else if (topLeft && !hasObject)
        {
            origin.position = new Vector3(-2.7f, 3.1f);
            middleG.SetActive(false);
        }
        else if (topRight && !hasObject)
        {
            origin.position = new Vector3(5.3f, 3.1f);
            middleG.SetActive(false);
        }
        else if (bottomLeft && !hasObject)
        {
            origin.position = new Vector3(-2.7f, -0.9f);
            middleG.SetActive(false);
        }
        else if (bottomRight && !hasObject)
        {
            origin.position = new Vector3(5.3f, -0.9f);
            middleG.SetActive(false);
        }
        else if (piece)
        {
            hasObject = true;
            pieceG.SetActive(false);
            middleG.SetActive(true);
            if (topLeft)
            {
                player.GetComponent<SpriteRenderer>().sprite = jacket;
            }
            else if (topRight)
            {
                player.GetComponent<SpriteRenderer>().sprite = pants;
            }
            else if (bottomLeft)
            {
                player.GetComponent<SpriteRenderer>().sprite = tie;
            }
            else if (bottomRight)
            {
                player.GetComponent<SpriteRenderer>().sprite = shoes;
            }

        }
    }
}

