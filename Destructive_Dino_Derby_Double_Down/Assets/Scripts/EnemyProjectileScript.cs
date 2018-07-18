using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour {
		private PlayerScript player;
		// Use this for initialization
		void Start () {
			player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
		}



		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.gameObject.CompareTag("Player") ){
				if (!player.invincible) {
					player.currentHealth--;
					player.invincible = true;
				}
				if (player.currentHealth == 0){
						other.gameObject.transform.position = player.lastCheckpoint;
						player.currentHealth = player.maxHealth;
					}
					Destroy(gameObject);
			}
		}

}
