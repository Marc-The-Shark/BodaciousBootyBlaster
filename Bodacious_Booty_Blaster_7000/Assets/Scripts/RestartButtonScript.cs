using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void restartGame() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
