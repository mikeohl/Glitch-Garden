using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, launcher;
	
	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner laneSpawner;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		SetLaneSpawner ();
		
		// Create Parent for defenders if necessary
		projectileParent = GameObject.Find ("Projectiles");
		
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	// Find spawner in same lane as shooting defender
	void SetLaneSpawner () {
		AttackerSpawner [] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawners) {
			if (spawner.transform.position.y == this.transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError ("Lane Spawner not found");
	}
	
	bool IsAttackerAheadInLane() {
		// Check if there are any attackers
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}
		
		// Check if any attacker is in front of a defender in the lane
		foreach (Transform attacker in laneSpawner.transform) {
			if (this.transform.position.x <= attacker.transform.position.x) {
				return true;
			}
		}
		
		// Attacker(s) not in from of Defender
		return false; 
	}
	
	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = launcher.transform.position;
	}
}
