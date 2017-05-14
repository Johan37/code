using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;

	void Start () {

	}
	
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " triggered");
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    // Called by the animator at time of actual blow
    public void StrikeCurrentTarget(float damage) {
        Debug.Log("Hit");
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }
}
