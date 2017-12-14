﻿using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost = 100;

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars (int amount) {
		starDisplay.AddStars (amount);
	}
}
