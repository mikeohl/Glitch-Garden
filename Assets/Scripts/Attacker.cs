﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float spawnTime;
	// [Range (-1.0f, 1.5f)]
	public float speed;
	
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		// Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		// myRigidbody.isKinematic = true;
		
		//defenderParent = GameObject.Find("Defenders");
		
		//if (!defenderParent) {
		//	defenderParent = new GameObject("Defenders");
		//}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		// Debug.Log (name + "Trigger Enter"); 
	}
	
	public void SetSpeed (float speed) {
		this.speed = speed;
	}
	
	// Called from the animator at the time of the actual attack
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			// Debug.Log (name + "doing " + damage + " damage.");
			currentTarget.GetComponent<Health>().DealDamage(damage);
		}	
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
