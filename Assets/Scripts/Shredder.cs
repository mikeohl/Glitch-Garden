/* Shredder handles the destruction of objects like 
 * projectiles that leave the play space without colliding
 * with an attacker or defender. 
 */

using UnityEngine;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D collider) {
        Destroy (collider.gameObject);
    }
}
