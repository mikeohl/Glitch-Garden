/* LoseCollider loads the lose screen when attackers breach the 
 * defenders and cross to the other end of the screen.
 */

using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    
    // Load lose screen on collision
    void OnTriggerEnter2D () {
        levelManager.LoadLevel ("03b Lose Screen");
        print ("lose collider");
    }
}
