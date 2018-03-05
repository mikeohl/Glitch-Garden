/* Fox handles attack and animation triggers for fox 
 * type attacker. 
 */

using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}

    // Attack (or jump over stone) and set animation 
    // trigger when collider is triggered by defender.
    void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<DefenderCurrency>()) {
			return;
		} 
        // Jump over a stone
		if (obj.GetComponent<Stone>()) {
			animator.SetTrigger ("Jump Trigger");
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
