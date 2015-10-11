using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	private bool facingRight;
	private float h;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// Use this for initialization
	void Start () {
		h = CrossPlatformInputManager.GetAxis("Horizontal");
		facingRight = false;
	}

	void FixedUpdate(){
		//Vector2 pos = new Vector2(groundCheck.transform.position.x, groundCheck.position.y);
		//grounded = GetComponent<Physics2D>().OverlapCircle(pos, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
		}
		if (Input.GetKey (KeyCode.D)) {
			if(facingRight && h < 0){
				Flip ();
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			if(!facingRight && h > 0){
				Flip ();
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
