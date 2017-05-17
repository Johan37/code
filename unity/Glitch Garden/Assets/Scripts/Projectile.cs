using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;

	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
