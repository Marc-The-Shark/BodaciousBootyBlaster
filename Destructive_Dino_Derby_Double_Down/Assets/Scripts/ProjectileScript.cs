using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy")){

			other.gameObject.GetComponent<EnemyScript>().health--;
			if (other.gameObject.GetComponent<EnemyScript>().health == 0){
					if (other.gameObject.name == "BigSprinkler") {
						 GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().projectileLevel += 100;
					}
					Destroy(other.gameObject);
				}
			Destroy(gameObject);
		}
	}
}
