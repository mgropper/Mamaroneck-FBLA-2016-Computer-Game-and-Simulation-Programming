using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {
	bool move = true;
	public GameObject player;
	public float moveSpeed;
	public float jumpHeight;
	private bool facingRight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private Animator anim;
	private float h;

	// Use this for initialization
	void Start () {
		facingRight = false;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		h = CrossPlatformInputManager.GetAxis("Horizontal");
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("speed", Mathf.Abs(h));
		anim.SetBool ("ground", grounded);
		if (move) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			}
			if (Input.GetKey (KeyCode.D)) {
				if (!facingRight) {
					Flip ();
					facingRight = true;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			} 
			if (Input.GetKey (KeyCode.A)) {
				if (facingRight) {
					Flip ();
					facingRight = false;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}

		}
	}

	void Flip(){
		player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
	}
}
