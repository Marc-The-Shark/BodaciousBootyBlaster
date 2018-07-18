using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public float deathLevel;

	public GameObject projectilePrefab;
	public float projectileSpeed;
	public float mouthHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	public float projectileLevel;
	public float destroyTime;

	public int currentHealth = 5;
	public int maxHealth = 5;

	public Vector3 lastCheckpoint;

	private Animator animator;
	public bool invincible = false;
	public bool invincibleCheck = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		projectileLevel = 0;
		lastCheckpoint = transform.position;
	}

	IEnumerator RemoveInvincibility() {
		Color oldColor = gameObject.GetComponent<SpriteRenderer>().color;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, 0.4f);
		yield return new WaitForSeconds(2);
		gameObject.GetComponent<SpriteRenderer>().color = oldColor;
		invincible = false;
		invincibleCheck = false;
	}

	Vector2 Rotate(Vector2 aPoint, float aDegree)
	{
		return Quaternion.Euler(0,0,aDegree) * aPoint;
	}

	// Update is called once per frame
	void Update () {

		if(invincible && !invincibleCheck) {
			invincibleCheck = true;
			StartCoroutine(RemoveInvincibility());
		}

		bool idle = true;
		bool look_left = animator.GetBool("look_left");

		grounded = Physics2D.OverlapArea (new Vector2(transform.position.x - 0.5f, transform.position.y - groundCheckRadius),
			new Vector2(transform.position.x + 0.5f, transform.position.y - groundCheckRadius - 0.01f), whatIsGround);

			if (Input.GetMouseButtonDown(0)) {
             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
             Vector2 myPos = new Vector2(transform.position.x,transform.position.y + mouthHeight);
             Vector2 direction = target - myPos;
             direction.Normalize();
						 if (projectileLevel == 0){
							 GameObject projectile = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
							 		projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

									 Destroy(projectile, destroyTime);
						}
						 else if (projectileLevel == 1) {
							 GameObject projectile1 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
							 GameObject projectile2 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);

							 projectile1.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 10) * projectileSpeed;
							 projectile2.GetComponent<Rigidbody2D>().velocity = Rotate(direction, -10) * projectileSpeed;
							 Destroy(projectile1, destroyTime);
							 Destroy(projectile2, destroyTime);
						 }

						 else if (projectileLevel >= 2 && projectileLevel < 100) {
							 GameObject projectile1 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
							 GameObject projectile2 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
							 GameObject projectile3 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);

							 projectile1.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 10) * projectileSpeed;
							 projectile2.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 0) * projectileSpeed;
							 projectile3.GetComponent<Rigidbody2D>().velocity = Rotate(direction, -10) * projectileSpeed;

							 Destroy(projectile1, destroyTime);
							 Destroy(projectile2, destroyTime);
							 Destroy(projectile3, destroyTime);

						 }

						 else if (projectileLevel >= 100) {

							 for (int i = 0; i < 36; i++) {
								 GameObject projectile = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
								 projectile.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 10 * i) * projectileSpeed;
								 Destroy(projectile, destroyTime);
							 }
						 }
         }

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
			transform.position =  lastCheckpoint;
			if (projectileLevel > 0) projectileLevel--;
			currentHealth--;
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
