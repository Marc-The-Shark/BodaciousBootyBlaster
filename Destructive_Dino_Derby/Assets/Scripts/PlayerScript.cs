using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public float deathLevel;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void fixedUpdate() {

//		grounded = Physics2D.OverlapArea (new Vector2(transform.position.x - groundCheckRadius, transform.position.y - groundCheckRadius),
//			new Vector2(transform.position.x + groundCheckRadius, transform.position.y - groundCheckRadius - 0.01f), whatIsGround);
	}
	// Update is called once per frame
	void Update () {

		bool idle = true;
		bool look_left = animator.GetBool("look_left");

		grounded = Physics2D.OverlapArea (new Vector2(transform.position.x - 0.5f, transform.position.y - groundCheckRadius),
			new Vector2(transform.position.x + 0.5f, transform.position.y - groundCheckRadius - 0.01f), whatIsGround);

		if (Input.GetKeyDown (KeyCode.W) && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (Input.GetKey (KeyCode.D)) {
			idle = false;
			look_left = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if (Input.GetKey (KeyCode.A)) {
			idle = false;
			look_left = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(gameObject.transform.position.y <=  deathLevel) {
			transform.position =  new Vector3(0, 0, transform.position.z);
		}

		animator.SetBool("idle", idle);
		animator.SetBool("look_left", look_left);
	}

	void onDrawGizmos() {
		Gizmos.color = new Color (0, 1, 0, 0.5f);
		Gizmos.DrawCube (new Vector2 (transform.position.x , transform.position.y - groundCheckRadius - 0.005f),
			new Vector2 (1, 0.01f));
	}
}
