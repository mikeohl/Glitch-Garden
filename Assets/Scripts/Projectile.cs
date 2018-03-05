/* Projectile controls the speed and damage of projectiles fired at
 * attackers by the defenders. The projectile deals damage and then
 * is destroyed on collision.
 */

using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    
    // Update is called once per frame
    // Move projectile each frame
    void Update () {
        transform.Translate (Vector3.right * speed * Time.deltaTime);
    }
    
    // Deal damage to attacker on collision and then destroy projectile
    void OnTriggerEnter2D (Collider2D collider) {
        
        GameObject attacker = collider.gameObject;
        
        // Assume attacker has Health script
        if (!attacker.GetComponent<Attacker>()) {
            return;
        } 
        attacker.GetComponent<Health>().DealDamage(damage);
        Destroy (gameObject);
    }
}
