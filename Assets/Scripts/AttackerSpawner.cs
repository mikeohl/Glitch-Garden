using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject [] attackerPrefabArray;
	
	// private float lastSpawnTime;
	private Attacker attacker;
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				// lastSpawnTime = Time.time;
				Spawn (thisAttacker);
			}
		}
	}
	
	bool isTimeToSpawn (GameObject thisAttacker) {
		attacker = thisAttacker.GetComponent<Attacker>();
		float spawnTime = attacker.spawnTime;
		float spawnsPerSecond = 1 / spawnTime;
		
		if (Time.deltaTime > spawnTime) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}
		
		float spawnsPerFrame = spawnsPerSecond * Time.deltaTime;
		
		return Random.value < spawnsPerFrame;
	}
	
	void Spawn (GameObject attacker) {
		GameObject newAttacker = Instantiate (attacker) as GameObject;
		newAttacker.transform.parent = this.transform;
		newAttacker.transform.position = this.transform.position;
	}
}
