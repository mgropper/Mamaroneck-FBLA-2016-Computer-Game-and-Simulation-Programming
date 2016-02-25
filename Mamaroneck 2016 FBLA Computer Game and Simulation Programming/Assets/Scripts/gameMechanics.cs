using UnityEngine;
using System.Collections;

public class gameMechanics : MonoBehaviour
{
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
	public GUIStyle afterTitle;
	public Font scoreMenuF;
	public GUIStyle time;
	public static bool record = false;
	private float currentSeconds = .0f;
	private float currentMinute = .0f;
	public GUIStyle retryButton;
	public static bool start = false;
	public float score = 0;
	public static bool scoreMenu = false;
	public Texture nextLevelT;
	public Texture mainMenuT;
	public Texture restartT;
	public Texture quitT;
	public GUIStyle buttonStyle; 

	// Use this for initialization
	void Start()
	{
		tutorial.pieceExplain = false;
		tutorial.scoreMenu = true;
		scoreMenu = false;
		tutorial.ele = false;
		tutorial.sli = false;
		tutorial.eleSli = false;
		tutorial.intro = false;
		tutorial.pauseRetry = false;
		middleG.SetActive (true);
		topRightG.SetActive (true);
		topLeftG.SetActive (false);
		bottomRightG.SetActive (false);
		bottomLeftG.SetActive (false);
		Menupause.pauseEnabled = false;
		Menupause.back = false;
		slider.able = true;
		elevator.able = true;
		PlatformerCharacter2D.ableFlip = true;
		record = false;
		scoreMenu = false;
		GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Platformer2DUserControl.h > 0.0 && !(GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints == RigidbodyConstraints2D.FreezeAll)) {
			record = true;
			start = true;
		}
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

		if (record && start) {
			currentSeconds += 1 * Time.deltaTime;
			if(Mathf.RoundToInt(currentSeconds) == 60){
				currentSeconds = 0;
				currentMinute++;
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
			if (wearing.Equals ("orig")) {
				area = "topRight";
				origin.position = new Vector3 (5.3f, 3.1f);
			} else if (wearing.Equals ("pants")) {
				area = "bottomRight";
				origin.position = new Vector3 (5.3f, -0.9f);
			} else if (wearing.Equals ("tie")) {
				area = "topLeft";
				origin.position = new Vector3 (-2.7f, 3.1f);
			} else if (wearing.Equals ("jacket")) {
				area = "bottomLeft";
				origin.position = new Vector3 (-2.7f, -0.9f);
			}
		} else if (hasObject && (player.transform.position.x < 3 && player.transform.position.x > -1) && !wearing.Equals ("shoes")) {
			hasObject = false;
			area = "middle";
			origin.position = new Vector3 (1.3f, 1.1f);
			if (wearing.Equals ("pants")) {
				topRightG.SetActive (false);
				bottomRightG.SetActive (true);
			} else if (wearing.Equals ("tie")) {
				bottomRightG.SetActive (false);
				topLeftG.SetActive (true);
			} else if (wearing.Equals ("jacket")) {
				topLeftG.SetActive (false);
				bottomLeftG.SetActive (true);
			}
		} else if (hasObject && (player.transform.position.x < 3 && player.transform.position.x > -.5f) && wearing.Equals ("shoes")) {
			record = false;
			GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			score =  120000 / ((currentMinute * 60) + currentSeconds);
			scoreMenu = true;
			PlatformerCharacter2D.ableFlip = false;
		}
	}

	void OnGUI(){
		GUI.skin.box.font = scoreMenuF;
		GUI.skin.button.font = scoreMenuF;
		GUI.skin.box.fontSize = 25;
		GUI.Label (new Rect (Screen.width / 2, 10, 50, 50), string.Format ("{0:00}:{1:00}", currentMinute, currentSeconds), time);
		if(Menupause.pauseEnabled || scoreMenu){
			GUI.Label (new Rect (50, 15, 25, 25), "Level " + (Application.loadedLevel - 1), afterTitle);
		}else{
			GUI.Label (new Rect (175, 25, 25, 25), "Level " + (Application.loadedLevel - 1), afterTitle);
		}
		if (!Menupause.pauseEnabled && !scoreMenu) {
			if ((GUI.Button (new Rect (70, 10, 50, 50), "", retryButton)) || Input.GetKey (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		if(scoreMenu){
			GUI.Box(new Rect(Screen.width/2 - 200, Screen.height / 2 - 190, 400, 100), "Score: " + Mathf.RoundToInt(score));
			if(GUI.Button (new Rect (Screen.width/2 - 175, Screen.height / 2 - 150, 50, 50), mainMenuT, buttonStyle)){
				Application.LoadLevel(0);
			}
			if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height / 2 - 150, 50, 50), restartT, buttonStyle)) {
				Application.LoadLevel (Application.loadedLevel);
			}
			if (GUI.Button (new Rect (Screen.width/2 + 25, Screen.height / 2 - 	150, 50, 50), quitT, buttonStyle)) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (Screen.width/2 + 125, Screen.height / 2 - 	150, 50, 50), nextLevelT, buttonStyle)) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
		}
	}
}