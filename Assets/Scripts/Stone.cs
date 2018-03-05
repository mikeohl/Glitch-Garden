/* Stone handles defense animation triggers for stone type defender. */

using UnityEngine;

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
