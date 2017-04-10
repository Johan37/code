﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		        if (Input.GetKey(KeyCode.LeftArrow)) {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0 ,0);
            transform.position += Vector3.left * speed * Time.deltaTime;
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
	}
}