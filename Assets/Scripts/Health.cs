﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DealDamage (float damage) {
		health -= damage;
		if (health <= 0.0f) {
			// Optionally trigger animation or ...
			DestroyObject ();
		}
	}
	
	public void DestroyObject () {
		Destroy (gameObject);
	}
}
