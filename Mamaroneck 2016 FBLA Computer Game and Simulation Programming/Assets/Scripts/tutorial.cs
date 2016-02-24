using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour
{
	public GameObject fake;
	public static bool intro = true;
	public static bool pauseRetry = false;
	public static bool pieceExplain = false;
	public static bool ele = false;
	public static bool sli = false;
	public static bool eleSli = false;
	public GUIStyle nextButton;
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
	public GUIStyle introTextStyle;
	public GUIStyle pauseRetryTextStyle;
	public Texture arrow;
	public Texture arrowB;
	public GameObject city;

	// Use this for initialization
	void Start ()
	{
		city.SetActive (false);
		scoreMenu = false;
		intro = true;
		pauseRetry = false;
		pieceExplain = false;
		ele = false;
		eleSli = false;
		sli = false;
		gameMechanics.scoreMenu = true;
		scoreMenu = false;
		player.GetComponent<SpriteRenderer> ().sprite = null;
		middleG.SetActive (false);
		topRightG.SetActive (false);
		topLeftG.SetActive (false);
		bottomRightG.SetActive (false);
		bottomLeftG.SetActive (false);
		slider.able = false;
		elevator.able = false;
		PlatformerCharacter2D.ableFlip = false;
		gameMechanics.record = false;
		GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		GameObject.Find ("Scripts").GetComponent<Menupause> ().enabled = false; 
		currentSeconds = .0f;
		currentMinute = .0f;
		record = false;
		player.transform.position = new Vector3 (1.3f, 1.1f, 0f);
	}
	// Update is called once per frame
	void Update ()
	{
		if (!intro) {
			if (Platformer2DUserControl.h > 0.0 && !(GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints == RigidbodyConstraints2D.FreezeAll)) {
				record = true;
				start = true;
			}
			if ((area.Equals ("topLeft") || area.Equals ("topRight")) && player.transform.position.y < -6) {
				player.transform.position = origin.transform.position;
				hasObject = (false);
				if (area.Equals ("topLeft")) {
					player.GetComponent<SpriteRenderer> ().sprite = tie;
					wearing = "tie";
					jacketP.SetActive (true);
					middleG.SetActive (false);
				} else if (area.Equals ("topRight")) {
					player.GetComponent<SpriteRenderer> ().sprite = orig;
					wearing = "orig";
					pantsP.SetActive (true);
					middleG.SetActive (false);
				}
			
			} else if ((area.Equals ("bottomLeft") || area.Equals ("bottomRight") || area.Equals ("middle")) && player.transform.position.y < -10) {
				player.transform.position = origin.position;
				hasObject = (false);
				if (area.Equals ("bottomLeft")) {
					player.GetComponent<SpriteRenderer> ().sprite = jacket;
					wearing = "jacket";
					shoesP.SetActive (true);
					middleG.SetActive (false);
				} else if (area.Equals ("bottomRight")) {
					player.GetComponent<SpriteRenderer> ().sprite = pants;
					wearing = "pants";
					tieP.SetActive (true);
					middleG.SetActive (false);
				}
			
			}
		
			if (record && start) {
				currentSeconds += 1 * Time.deltaTime;
				if (Mathf.RoundToInt (currentSeconds) == 60) {
					currentSeconds = 0;
					currentMinute++;
				}
			}
		}
	}
	
	void OnTriggerEnter2D ()
	{
		if (!hasObject && (player.transform.position.x < -16.4 || player.transform.position.x > 16.4)) {
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
		} else if (!hasObject && ((player.transform.position.x > 3.2 && player.transform.position.x < 8.0) || (player.transform.position.x < -1.1 && player.transform.position.x > -8))) {
			middleG.SetActive (false);
			if (wearing.Equals ("orig")) {
				area = "topRight";
				origin.position = new Vector3 (5.3f, 3.1f);
			} else if (wearing.Equals ("pants")) {
				area = "bottomRight";
				ele = true;
				PlatformerCharacter2D.ableFlip = false;
				record = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				origin.position = new Vector3 (5.3f, -0.9f);
			} else if (wearing.Equals ("tie")) {
				area = "topLeft";
				sli = true;
				PlatformerCharacter2D.ableFlip = false;
				record = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				origin.position = new Vector3 (-2.7f, 3.1f);
			} else if (wearing.Equals ("jacket")) {
				area = "bottomLeft";
				eleSli = true;
				PlatformerCharacter2D.ableFlip = false;
				record = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				origin.position = new Vector3 (-2.7f, -0.9f);
			}
		} else if (!hasObject && (player.transform.position.x > 14.6 && player.transform.position.x < 16.3)) {
			pieceExplain = true;
			slider.able = false;
			elevator.able = false;
			PlatformerCharacter2D.ableFlip = false;
			record = false;
			GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		}else if (hasObject && (player.transform.position.x < 3 && player.transform.position.x > -1) && !wearing.Equals ("shoes")) {
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
		} else if (hasObject && (player.transform.position.x < 3 && player.transform.position.x > 0) && wearing.Equals ("shoes")) {
			record = false;
			slider.able = false;
			elevator.able = false;
			GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			score = 45000 / ((currentMinute * 60) + currentSeconds);
			scoreMenu = true;
			PlatformerCharacter2D.ableFlip = false;
		}
	}
	
	void OnGUI ()
	{
		GUI.skin.box.font = scoreMenuF;
		GUI.skin.button.font = scoreMenuF;
		GUI.skin.box.fontSize = 25;
		if (!intro) {
			GUI.Label (new Rect (Screen.width / 2, 10, 50, 50), string.Format ("{0:00}:{1:00}", currentMinute, currentSeconds), time);
			if (Menupause.pauseEnabled || scoreMenu) {
				GUI.Label (new Rect (50, 15, 25, 25), "Tutorial", afterTitle);
			} else {
				GUI.Label (new Rect (175, 25, 25, 25), "Tutorial", afterTitle);
			}
			if (!Menupause.pauseEnabled && !scoreMenu) {
				if (((GUI.Button (new Rect (70, 10, 50, 50), "", retryButton)) || Input.GetKey (KeyCode.R)) && (!intro && !pauseRetry && !pieceExplain && !ele && !sli && !eleSli)) {
					Application.LoadLevel (Application.loadedLevel);
				}
			}
			if (scoreMenu) {
				GUI.Box (new Rect (Screen.width/2 - 200, Screen.height / 2 - 190, 400, 100), "Score: " + Mathf.RoundToInt (score));
				if (GUI.Button (new Rect (Screen.width/2 - 175, Screen.height / 2 - 150, 50, 50), mainMenuT, buttonStyle)) {
					Application.LoadLevel (0);
				}
				if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height / 2 - 150, 50, 50), restartT, buttonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
				}
				if (GUI.Button (new Rect (Screen.width/2 + 25, Screen.height / 2 - 150, 50, 50), quitT, buttonStyle)) {
					Application.Quit ();
				}
				if (GUI.Button (new Rect (Screen.width/2 + 125, Screen.height / 2 - 150, 50, 50), nextLevelT, buttonStyle)) {
					Application.LoadLevel (Application.loadedLevel + 1);
				}
			}
		}
		if (intro) {
			GUI.Label (new Rect (Screen.width/2-100, 10, 200, 200), "This is Barney. He is a successful businessman, but he suffers from\ndream anxiety disorder. Combined with his fear of being late and of\nheights, he has nightmares every night in which he loses his clothes\nin the sky right before an important meeting.\n\nCan you help Barney find his clothes so he can wake up from his nightmare?", introTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				intro = false;
				GameObject.Find ("Scripts").GetComponent<Menupause> ().enabled = true; 
				middleG.SetActive (true);
				topRightG.SetActive (true);
				city.SetActive (true);
				fake.SetActive(false);
				player.SetActive(true);
				player.GetComponent<SpriteRenderer> ().sprite = orig;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				pauseRetry = true;
			}
		}
		if (pauseRetry) {
			GUI.DrawTexture(new Rect(-5, 55, 75, 100), arrow);
			GUI.DrawTexture(new Rect(55, 55, 75, 100), arrow);
			GUI.DrawTexture(new Rect(145, 45, 75, 100), arrow);
			GUI.DrawTexture(new Rect(Screen.width/2 - 37, 45, 75, 100), arrow);
			GUI.DrawTexture(new Rect(-5, 80, 75, 100), arrowB);
			GUI.DrawTexture(new Rect(-5, 105, 75, 100), arrowB);
			GUI.DrawTexture(new Rect(55, 80, 75, 100), arrowB);
			GUI.Label (new Rect(115, 150, 75, 100), "This button pauses the game, use 'esc' as well.", pauseRetryTextStyle);
			GUI.Label (new Rect(200, 125, 75, 100), "This button restarts the current level, use 'r' as well. ", pauseRetryTextStyle);
			GUI.Label (new Rect(205, 90, 75, 100), "This is the current level.", pauseRetryTextStyle);
			GUI.Label (new Rect(Screen.width/2 + 100, 100, 75, 100), "This is the current time, be careful of it.", pauseRetryTextStyle);
			GUI.Label (new Rect(Screen.width - 225, Screen.height - 375, 75, 100), "Use A and D or the arrow keys to move left and right.\nUse space to jump.", pauseRetryTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				pauseRetry = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
				Menupause.pauseEnabled = false;
				Menupause.back = false;
				slider.able = true;
				city.SetActive (true);
				elevator.able = true;
				PlatformerCharacter2D.ableFlip = true;
				record = false;
				scoreMenu = false;
			}
		}
		if (pieceExplain) {
			GUI.Label(new Rect(Screen.width - 450, Screen.height/2 + 53, 75, 100), "This is a piece of Barney's suit.\nPick it up and go back to the beginning to unlock the next path to the next piece", pauseRetryTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				pieceExplain = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
				Menupause.pauseEnabled = false;
				Menupause.back = false;
				slider.able = true;
				elevator.able = true;
				city.SetActive (true);
				PlatformerCharacter2D.ableFlip = true;
				record = true;
			}
		}
		if(ele){
			GUI.Label (new Rect(Screen.width - 400, 150, 100, 75), "There is an elevator cloud, it goes up and down", pauseRetryTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				ele = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
				Menupause.pauseEnabled = false;
				Menupause.back = false;
				slider.able = true;
				city.SetActive (true);
				elevator.able = true;
				PlatformerCharacter2D.ableFlip = true;
				record = true;
			}
		}
		if(sli){
			GUI.Label (new Rect(250, 100, 100, 75), "There is a slider cloud, it goes left and right\nMake sure to stay with it.", pauseRetryTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				sli = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
				Menupause.pauseEnabled = false;
				Menupause.back = false;
				slider.able = true;
				city.SetActive (true);
				elevator.able = true;
				PlatformerCharacter2D.ableFlip = true;
				record = true;
			}
		}
		if(eleSli){
			GUI.Label (new Rect(350, 150, 100, 75), "Elevators and sliders can be next to each other", pauseRetryTextStyle);
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 125, 75), "Next", nextButton)) {
				eleSli = false;
				GameObject.Find ("character").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
				Menupause.pauseEnabled = false;
				Menupause.back = false;
				slider.able = true;
				city.SetActive (true);
				elevator.able = true;
				PlatformerCharacter2D.ableFlip = true;
				record = true;
			}
		}
	}
}