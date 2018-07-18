using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Image HeartUI;
	private PlayerScript player;

	// Use this for initialization
	void Start () {
		player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		HeartUI.sprite = HeartSprites[player.currentHealth];
	}
}
