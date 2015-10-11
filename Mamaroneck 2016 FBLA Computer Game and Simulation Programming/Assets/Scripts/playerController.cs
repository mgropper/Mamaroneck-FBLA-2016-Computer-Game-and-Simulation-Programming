using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {
	bool move = true;
	public GameObject player;
	public float moveSpeed;
	public float jumpHeight;
	private bool facingRight;
	private float h;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool once = true;
	private Animator anim;

	// Use this for initialization
	void Start () {
		facingRight = false;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){

		//Vector2 pos = new Vector2(groundCheck.transform.position.x, groundCheck.position.y);
		//grounded = GetComponent<Physics2D>().OverlapCircle(pos, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		h = CrossPlatformInputManager.GetAxis("Horizontal");
		if (move) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			}
			if (Input.GetKey (KeyCode.D)) {
				if (!facingRight && once) {
					once = false;
					Flip ();
					facingRight = true;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			} 
			if(Input.GetKeyUp(KeyCode.D)){
				once = true;
			}
			if (Input.GetKey (KeyCode.A)) {
				if (facingRight && once) {
					once = false;
					Flip ();
					facingRight = false;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}
			if(Input.GetKeyUp(KeyCode.A)){
				once = true;
			}
			anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		}
	}

	void Flip(){
		player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
	}
}
