/* Lizard handles attack and animation triggers for lizard 
 * type attacker. 
 */

using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}

    // Attack and set animation trigger when collider 
    // is triggered by defender.
    void OnTriggerEnter2D (Collider2D collider) {		
		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<DefenderCurrency>()) {
			return;
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
