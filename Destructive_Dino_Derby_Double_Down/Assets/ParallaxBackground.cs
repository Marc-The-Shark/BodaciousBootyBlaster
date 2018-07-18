using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	// public bool scrolling, paralax;

	public float backgroundSize;
	public float paralaxSpeed;

	private float viewZone;
	private Transform cameraTransform;
	private Transform[] layers;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;


	// Use this for initialization
	void Start () {
		viewZone = Camera.main.orthographicSize;
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void scrollLeft() {
		int lastRight = rightIndex;
		layers[rightIndex].position = new Vector3(layers [leftIndex].position.x - backgroundSize, layers[rightIndex].position.y, layers[rightIndex].position.z);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void scrollRight() {
		int lastLeft = leftIndex;
		layers [leftIndex].position = new Vector3(layers [rightIndex].position.x + backgroundSize, layers[rightIndex].position.y, layers[rightIndex].position.z);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
	// Update is called once per frame
	void Update () {
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right *(deltaX *paralaxSpeed);
		lastCameraX = cameraTransform.position.x;

		if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)){
			scrollLeft();
		}

		if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)){
			scrollRight();
		}
	}
}
