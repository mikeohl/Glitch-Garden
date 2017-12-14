using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D (Collider2D collider) {
		attacker = collider.gameObject.GetComponent<Attacker>();
		if (attacker) {
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
