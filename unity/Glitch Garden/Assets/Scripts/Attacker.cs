using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds spawn")]
    public float seenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " triggered");
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    // Called by the animator at time of actual blow
    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }

    // Called on collision with enemy
    public void Attack(GameObject obj) {
        currentTarget = obj;
    }
}
