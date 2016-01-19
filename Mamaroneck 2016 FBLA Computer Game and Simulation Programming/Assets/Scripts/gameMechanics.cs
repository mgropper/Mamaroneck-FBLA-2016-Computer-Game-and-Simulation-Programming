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
    public bool piece = true;
    public GameObject hasObject;
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
	public GameObject area;

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
			hasObject.SetActive(false);
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
			hasObject.SetActive(false);
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
		if (piece)
		{
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
				player.GetComponent<SpriteRenderer>().sprite = shoes;
			}
			else if (bottomRight)
			{
				player.GetComponent<SpriteRenderer>().sprite = tie;
			}
			hasObject.SetActive(true);
			pieceG.SetActive(false);
			
		}else if (middle)
        {
            origin.position = new Vector3(1.3f, 1.1f);
            if (hasObject.activeInHierarchy && area.name.Equals("topLeft") && !piece)
            {
                hasObject.SetActive(false);
                topLeftG.SetActive(false);
            }
            if (hasObject.activeInHierarchy && area.name.Equals("topRight") && !piece)
            {
                bottomRightG.SetActive(true);
                topRightG.SetActive(false);
                hasObject.SetActive(false);
            }
		    if (hasObject.activeInHierarchy && area.name.Equals("bottomLeft") && !piece)
            {
                Application.LoadLevel(2);
            }
			if (hasObject.activeInHierarchy && area.name.Equals("bottomRight") && !piece)
            {
                topLeftG.SetActive(true);
                bottomRightG.SetActive(false);
				hasObject.SetActive(false);
            }
        }
		else if (topLeft && !hasObject.activeInHierarchy)
        {
            origin.position = new Vector3(-2.7f, 3.1f);
            middleG.SetActive(false);
			area.name = "topLeft";
        }
		else if (topRight && !hasObject.activeInHierarchy)
        {
            origin.position = new Vector3(5.3f, 3.1f);
            middleG.SetActive(false);
			area.name = "topRight";
        }
		else if (bottomLeft && !hasObject.activeInHierarchy)
        {
            origin.position = new Vector3(-2.7f, -0.9f);
            middleG.SetActive(false);
			area.name = "bottomLeft";
        }
		else if (bottomRight && !hasObject.activeInHierarchy)
        {
            origin.position = new Vector3(5.3f, -0.9f);
            middleG.SetActive(false);
			area.name = "bottomRight";
        } 
    }
}

