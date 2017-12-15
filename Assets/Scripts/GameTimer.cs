using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelTimeInSeconds = 100;
	
	private Slider slider;
	private LevelManager levelmanager;
	private AudioSource audioSource;
	private bool levelComplete = false;
	private GameObject winLabel;
	

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("You Won");
		if (!winLabel) {
			Debug.LogWarning("No Win UI Text for victory"); 
		} else {
			winLabel.SetActive(false);
		}
		
		slider.value = slider.minValue =  0;
		slider.maxValue = levelTimeInSeconds;
	}
	
	// Update is called once per frame
	// TODO: Fix instance where enemy hits lose collider while victory music is playing causing loss.
	void Update () {
		slider.value += Time.deltaTime;
		if (slider.value >= levelTimeInSeconds && !levelComplete) {
			DestroyAllTaggedObjects();
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			levelComplete = true;
		}
	}
	
	// Destroys all Objects with destroyOnWin tag
	void DestroyAllTaggedObjects () {
		GameObject [] gameObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject gameObject in gameObjects) {
			// Debug.Log (gameObject);
			Destroy(gameObject);
		}
	}
	
	void LoadNextLevel () {
		levelmanager.LoadNextLevel();
	}
}
