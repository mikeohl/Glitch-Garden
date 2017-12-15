using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		// Debug.Log (name + " collided with " + collider); 
		
		GameObject attacker = collider.gameObject;
		
		// Assume attacker has Health script
		if (!attacker.GetComponent<Attacker>()) {
			return;
		} 
		attacker.GetComponent<Health>().DealDamage(damage);
		Destroy (gameObject);
	}
}
