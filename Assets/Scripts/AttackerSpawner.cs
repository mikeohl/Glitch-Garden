/* AttackSpawner spawns attackers into the game with check to 
 * IsTimeToSpawn and Spawn functions 
 */

using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	public GameObject [] attackerPrefabArray;
	
	// private float lastSpawnTime;
	private Attacker attacker;
	
	// Update is called once per frame
    // Check if a new attacker should be spawned
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

    // Check if an enemy should be spawned according to attacker's 
    // spawn time frequency. [Randomized about spawn frequency]
	private bool IsTimeToSpawn (GameObject thisAttacker) {
		attacker = thisAttacker.GetComponent<Attacker>();

        // Log warning if attacker spawn time exceeds frame rate
        if (Time.deltaTime > attacker.spawnTime) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float spawnsPerSecond = 1 / attacker.spawnTime;
		float spawnsPerFrame = spawnsPerSecond * Time.deltaTime;
		
        // Check against random value to randomize around frequency
		return Random.value < spawnsPerFrame;
	}
	
	private void Spawn (GameObject attacker) {
		GameObject newAttacker = Instantiate (attacker) as GameObject;
		newAttacker.transform.parent = this.transform;
		newAttacker.transform.position = this.transform.position;
	}
}
