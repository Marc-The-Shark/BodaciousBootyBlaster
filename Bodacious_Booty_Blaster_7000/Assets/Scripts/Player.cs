using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	public static Player instance = null;
	private Rigidbody rb;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float bulletSpeed;
	public float bulletDestroyTime;

	public GameObject restartButton;

	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		Vector3 movement;

		if (Input.GetKey (KeyCode.A)) {
			movement = new Vector3 (-1, 0.0f, 0.0f);
			rb.AddForce (movement * speed);
		}
		if (Input.GetKey (KeyCode.D)) {
			movement = new Vector3 (1, 0.0f, 0.0f);
			rb.AddForce (movement * speed);
		}
		if (Input.GetKey (KeyCode.S)) {
			movement = new Vector3 (0.0f, 0.0f, -1);
			rb.AddForce (movement * speed);
		}
		if (Input.GetKey (KeyCode.W)) {
			movement = new Vector3 (0.0f, 0.0f, 1);
			rb.AddForce (movement * speed);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
			
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
		// Debug.Log("target is " + screenPos.x + " pixels from the left");
	}

	void Fire() {
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, bulletDestroyTime);     
	}
}
