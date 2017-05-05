using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(-1f, 1.5f)] public float walkSpeed;

	void Start () {
		
	}
	
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);

	}
}
