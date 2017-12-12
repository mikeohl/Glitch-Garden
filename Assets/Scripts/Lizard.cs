﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (name + " collided with " + collider); 
		
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender>()) {
			return;
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}