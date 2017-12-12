using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(PlayerPrefsManager.GetMasterVolume ());
		PlayerPrefsManager.SetMasterVolume (0.3f);
		print(PlayerPrefsManager.GetMasterVolume ());
		
		print(PlayerPrefsManager.IsLevelUnlocked(2));
		PlayerPrefsManager.UnlockLevel (2);
		print(PlayerPrefsManager.IsLevelUnlocked(2));
		
		print(PlayerPrefsManager.GetDifficulty());
		PlayerPrefsManager.SetDifficulty (1.5f);
		print(PlayerPrefsManager.GetDifficulty());
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
