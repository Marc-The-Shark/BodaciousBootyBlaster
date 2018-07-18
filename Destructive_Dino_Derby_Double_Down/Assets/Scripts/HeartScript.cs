using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour {

	private PlayerScript player;
	// Use this for initialization
	void Start () {
		player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
			if (player.currentHealth < player.maxHealth){
				Destroy(gameObject);
				player.currentHealth++;
			}
	}
}
