using UnityEngine;
using System.Collections;

public class gameMechanics : MonoBehaviour
{
    /*public Transform origin;
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
    }*/

	public Transform origin;
	public GameObject player;
	public bool hasObject = false;
	public GameObject topLeftG;
	public GameObject topRightG;
	public GameObject bottomLeftG;
	public GameObject bottomRightG;
	public GameObject middleG;
	public GameObject pantsP;
	public GameObject tieP;
	public GameObject jacketP;
	public GameObject shoesP;
	public Sprite orig;
	public Sprite pants;
	public Sprite tie;
	public Sprite jacket;
	public Sprite shoes;
	private string area = "middle";
	private string wearing = "orig";
	
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
		if ((area.Equals("topLeft") || area.Equals("topRight")) && player.transform.position.y < -6)
		{
			player.transform.position = origin.transform.position;
			hasObject = (false);
			if (area.Equals("topLeft"))
			{
				player.GetComponent<SpriteRenderer>().sprite = tie;
				wearing = "tie";
				jacketP.SetActive(true);
				middleG.SetActive(false);
			}
			else if (area.Equals("topRight"))
			{
				player.GetComponent<SpriteRenderer>().sprite = orig;
				wearing = "orig";
				pantsP.SetActive(true);
				middleG.SetActive(false);
			}

		}
		else if ((area.Equals("bottomLeft") || area.Equals("bottomRight") || area.Equals("middle")) && player.transform.position.y < -10)
		{
			player.transform.position = origin.position;
			hasObject = (false);
			if (area.Equals("bottomLeft"))
			{
				player.GetComponent<SpriteRenderer>().sprite = jacket;
				wearing = "jacket";
				shoesP.SetActive(true);
				middleG.SetActive(false);
			}
			else if (area.Equals("bottomRight"))
			{
				player.GetComponent<SpriteRenderer>().sprite = pants;
				wearing = "pants";
				tieP.SetActive(true);
				middleG.SetActive(false);
			}

		}
	}
	
	void OnTriggerEnter2D()
	{
		if (!hasObject && (player.transform.position.x < -60 || player.transform.position.x > 60)) {
			middleG.SetActive (true);
			hasObject = true;
			if (wearing.Equals ("orig")) {
				pantsP.SetActive (false);
				player.GetComponent<SpriteRenderer> ().sprite = pants;
				wearing = "pants";
			} else if (wearing.Equals ("pants")) {
				player.GetComponent<SpriteRenderer> ().sprite = tie;
				wearing = "tie";
				tieP.SetActive (false);
			} else if (wearing.Equals ("tie")) {
				player.GetComponent<SpriteRenderer> ().sprite = jacket;
				wearing = "jacket";
				jacketP.SetActive (false);
			} else if (wearing.Equals ("jacket")) {
				player.GetComponent<SpriteRenderer> ().sprite = shoes;
				wearing = "shoes";
				shoesP.SetActive (false);
			}
		} else if (!hasObject && ((player.transform.position.x > 3.2 && player.transform.position.x < 10) || (player.transform.position.x < -1.1 && player.transform.position.x > -10))) {
			middleG.SetActive (false);
			if(wearing.Equals("orig")){
				area = "topRight";
				origin.position = new Vector3(5.3f, 3.1f);
			}else if(wearing.Equals("pants")){
				area = "bottomRight";
				origin.position = new Vector3(5.3f, -0.9f);
			}else if(wearing.Equals("tie")){
				area = "topLeft";
				origin.position = new Vector3(-2.7f, 3.1f);
			}else if(wearing.Equals("jacket")){
				area = "bottomLeft";
				origin.position = new Vector3(-2.7f, -0.9f);
			}
		} else if (hasObject && (player.transform.position.x < 3 && player.transform.position.x > -1)) {
			hasObject = false;
			area = "middle";
			origin.position = new Vector3(1.3f, 1.1f);
			if(wearing.Equals("pants")){
				topRightG.SetActive(false);
				bottomRightG.SetActive(true);
			}else if(wearing.Equals("tie")){
				bottomRightG.SetActive(false);
				topLeftG.SetActive(true);
			}else if(wearing.Equals("jacket")){
				topLeftG.SetActive(false);
				bottomLeftG.SetActive(true);
			}else if(wearing.Equals("shoes")){
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		/*if (!hasObject && !area.Equals("middle"))
		{
			middleG.SetActive(true);
			hasObject = true;
			if (area.Equals("topLeft"))
			{
				player.GetComponent<SpriteRenderer>().sprite = jacket;
				wearing = "jacket";
				jacketP.SetActive(false);
			}
			else if (area.Equals("topRight"))
			{
				player.GetComponent<SpriteRenderer>().sprite = pants;
				wearing = "pants";
				pantsP.SetActive(false);
			}
			else if (area.Equals("bottomLeft"))
			{
				player.GetComponent<SpriteRenderer>().sprite = shoes;
				wearing = "shoes";
				shoesP.SetActive(false);
			}
			else if (area.Equals("bottomRight"))
			{
				player.GetComponent<SpriteRenderer>().sprite = tie;
				wearing = "tie";
				tieP.SetActive(false);
			}
			
		}else if (hasObject)
		{
			origin.position = new Vector3(1.3f, 1.1f);
			if (area.Equals("topLeft"))
			{
				hasObject = (false);
				topLeftG.SetActive(false);
				area = "middle";
			}
			if (area.Equals("topRight"))
			{
				bottomRightG.SetActive(true);
				topRightG.SetActive(false);
				hasObject = (false);
				area = "middle";
			}
			if (area.Equals("bottomLeft"))
			{
				Application.LoadLevel(2);
			}
			if (area.Equals("bottomRight"))
			{
				topLeftG.SetActive(true);
				bottomRightG.SetActive(false);
				hasObject = (false);
				area = "middle";
			}
		}
		else if (wearing.Equals("tie") && !hasObject && area.Equals("middle"))
		{
			origin.position = new Vector3(-2.7f, 3.1f);
			middleG.SetActive(false);
			area = "topLeft";
		}
		else if (wearing.Equals("orig") && !hasObject && area.Equals("middle"))
		{
			origin.position = new Vector3(5.3f, 3.1f);
			middleG.SetActive(false);
			area = "topRight";
		}
		else if (wearing.Equals("pants") && !hasObject && area.Equals("middle"))
		{
			origin.position = new Vector3(-2.7f, -0.9f);
			middleG.SetActive(false);
			area = "bottomLeft";
		}
		else if (wearing.Equals("jacket") && !hasObject && area.Equals("middle"))
		{
			origin.position = new Vector3(5.3f, -0.9f);
			middleG.SetActive(false);
			area = "bottomRight";
		} */
	}
}