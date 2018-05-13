using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject[] enemies;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public float startWait;
	public bool stop;

	int randEnemy;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawner ());
	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

	IEnumerator Spawner() 
	{
		yield return new WaitForSeconds (startWait);

		while (!stop) 
		{
			randEnemy = Random.Range (0, 2);

			Vector3 spawnPosition = new Vector3 (gameObject.transform.position.x, 0, Random.Range (-spawnValues.z, spawnValues.z));
			Instantiate (enemies [randEnemy], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
