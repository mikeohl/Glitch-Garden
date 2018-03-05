/* AttackSpawner spawns attackers into the game with check to 
 * IsTimeToSpawn and Spawn functions 
 */

using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	public GameObject [] attackerPrefabArray;
    public float minDeltaAttackTime;
	
	// private float lastSpawnTime;
	private Attacker attacker;
    private float lastAttackTime;

    // Use this for initialization
    void Start () {
        lastAttackTime = Time.time;
    }

    // Update is called once per frame
    // Check if a new attacker should be spawned
    void Update () {
        // Don't allow attackers to spawn over each other.
        if (Time.time - lastAttackTime > minDeltaAttackTime) {
            foreach (GameObject thisAttacker in attackerPrefabArray) {
                if (IsTimeToSpawn(thisAttacker)) {
                    //print("hello");
                    Spawn(thisAttacker);
                    lastAttackTime = Time.time;
                }
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
