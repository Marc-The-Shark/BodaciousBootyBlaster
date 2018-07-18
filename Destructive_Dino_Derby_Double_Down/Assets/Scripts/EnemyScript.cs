using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

	public GameObject projectilePrefab;
	public int health = 2;
	public float mouthHeight;
	public float projectileSpeed;
	private PlayerScript player;

	public float projectileDeathTime = 2f;

	public GameObject[] rewards;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		if (Random.Range(0, 30) == 5 ) shoot();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player")){
			if (other.gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0){
				player.currentHealth--;
			}
			else{
					Destroy(gameObject);
				}
		}
	}

	Vector2 Rotate(Vector2 aPoint, float aDegree)
	{
		return Quaternion.Euler(0,0,aDegree) * aPoint;
	}

	void OnDestroy () {
		int index = Random.Range(0, rewards.Length + 1);
		Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
		if(index != rewards.Length) {
			Instantiate(rewards[index], myPos, Quaternion.identity);
		}
	}

	void shoot(){
		Vector2 myPos = new Vector2(transform.position.x,transform.position.y + mouthHeight);
		Vector2 direction = new Vector2(transform.position.x,transform.position.y + mouthHeight + 1) - myPos;
		direction.Normalize();

		GameObject projectile1 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
		GameObject projectile2 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
		GameObject projectile3 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);
		GameObject projectile4 = (GameObject)Instantiate( projectilePrefab, myPos, Quaternion.identity);

		projectile1.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 20) * projectileSpeed;
		projectile2.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 10) * projectileSpeed;
		projectile3.GetComponent<Rigidbody2D>().velocity = Rotate(direction, -10) * projectileSpeed;
		projectile4.GetComponent<Rigidbody2D>().velocity = Rotate(direction, -20) * projectileSpeed;

		Destroy(projectile1, projectileDeathTime);
		Destroy(projectile2, projectileDeathTime);
		Destroy(projectile3, projectileDeathTime);
		Destroy(projectile4, projectileDeathTime);
	}

}
