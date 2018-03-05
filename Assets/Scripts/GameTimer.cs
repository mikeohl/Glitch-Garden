/* GameTimer updates Timer slider and loads next level when time expires */

using UnityEngine;
using UnityEngine.UI;

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

        // Set win-game text to inactive to start the game
        if (!winLabel) {
            Debug.LogWarning("No Win UI Text for victory"); 
        } else {
            winLabel.SetActive(false);
        }
        
        // Start level timer slider at 0
        slider.value = slider.minValue =  0;
        slider.maxValue = levelTimeInSeconds;
    }
    
    // Update is called once per frame
    // Update the game timer slider and handle win condition if time is up
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
    
    // Destroys all Objects with destroyOnWin tag to prevent triggering lose collider
    // after winning game
    void DestroyAllTaggedObjects () {
        GameObject [] gameObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject gameObject in gameObjects) {
            Destroy(gameObject);
        }
    }
    
    // levelManager LoadNextLevel function for Invoke call
    void LoadNextLevel () {
        levelmanager.LoadNextLevel();
    }
}
