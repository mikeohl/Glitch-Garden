/* Health manages health points for attackers and defenders.
 * Attackers and defenders can be destroyed if health falls
 * too low.
 */

using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100.0f;
    
    // Adjust health to incoming damage and destory object
    // when health is gone
    public void DealDamage (float damage) {
        health -= damage;
        if (health <= 0.0f) {
            // TODO: Possibly trigger new animation, then...
            DestroyObject ();
        }
    }
    
    public void DestroyObject () {
        Destroy (gameObject);
    }
}
