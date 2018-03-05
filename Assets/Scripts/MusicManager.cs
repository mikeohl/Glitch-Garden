/* MusicPlayer initiates music track for each specific level
 * through a persistent music player instance. Volume can be
 * set by player through menu slider that calls SetVolume.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    
    private AudioSource audioSource;

    // Play music when scene is loaded through Unity SceneManagement
    void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        int level = scene.buildIndex;
        AudioClip thisLevelMusic = levelMusicChangeArray[level];

        Debug.Log("Playing clip: " + thisLevelMusic);

        // Play music if there music is found for level
        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Awake () {
        DontDestroyOnLoad (gameObject);
        Debug.Log ("Don't destroy on load: " + name);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    public void SetVolume (float newVolume) {
        audioSource.volume = newVolume;
    }
}
