using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour {

	public float amplitude = 5;
	public bool left = true;
	public float speed = 4;

	private float originalX;

	public PlayerScript player;

	// Use this for initialization
	void Start () {
		originalX = transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		if (left) {
			if(transform.position.x <= originalX - amplitude) {
				left = false;
				transform.Translate(speed, 0, 0);
			}
			else transform.Translate(-speed, 0, 0);
		}
		else {
			if (transform.position.x >= originalX + amplitude) {
				left = true;
				transform.Translate(-speed, 0, 0);
			}
			else transform.Translate(speed, 0, 0);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Projectile"))
			Destroy(gameObject);
			player.projectileLevel++;
	}
}
