using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	static int destroyed = 0;
	private GameObject scoreboard;
	public GameObject restartButton;
	public GameObject explosion;


	// Use this for initialization
	void Start () {
		scoreboard = GameObject.Find("Scoreboard");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "Bullet(Clone)"){
			Destroy (collision.gameObject);
			Instantiate (explosion, transform);
			explosion.GetComponent<ParticleSystem> ().Play ();
			Destroy (gameObject);
			destroyed++;
			updateScoreBoard ();
			//Destroy (explosion, 5);
		}

		else if(collision.gameObject.name == "Player"){
			Destroy(collision.gameObject);
			Instantiate(restartButton, GameObject.Find ("Canvas").transform);
		}
	}

	void updateScoreBoard() {
		scoreboard.GetComponent<UnityEngine.UI.Text> ().text = (destroyed * 100).ToString();
	}

}
