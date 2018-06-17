using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform playerTransform;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
//		if ( gameObject.transform.position.x != playerTransform.position.x) {
//			
		gameObject.transform.Translate(playerTransform.position.x - gameObject.transform.position.x, playerTransform.position.y - gameObject.transform.position.y, 0);

	}
}
