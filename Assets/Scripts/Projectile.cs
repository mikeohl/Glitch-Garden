using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (name + " collided with " + collider); 
		
		GameObject obj = collider.gameObject;
		
		// Assume attacker has Health script
		if (!obj.GetComponent<Attacker>()) {
			return;
		} 
		obj.GetComponent<Health>().DealDamage(damage);
		Destroy (gameObject);
	}
}
