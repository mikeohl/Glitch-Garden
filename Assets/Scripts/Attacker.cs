/* Attacker.cs controls movement speed of the attacker at the 
 * defender, setting the current target, and setting animation
 * boolean trigger for attack animation.
 */

using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearances")]
    public float spawnTime;
    public float speed;     // [Suggested Range (-1.0f, 1.5f)]

    private GameObject currentTarget;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Move attacker across the screen and set animation trigger if 
    // attacker has a target
    void Update () {
        transform.Translate (Vector3.left * speed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
    }

    // Called from the animator at the time of the actual attack
    public void StrikeCurrentTarget (float damage) {
        if (currentTarget) {
            currentTarget.GetComponent<Health>().DealDamage(damage);
        }	
    }
    
    // Set defender object as current target for attacker
    public void Attack (GameObject obj) {
        currentTarget = obj;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}
