﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float padding;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;
    public float health = 200f;

    public AudioClip fireSound;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
    	Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0 ,distance));
    	Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0 ,distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
	}
	
    void Fire() {
        Vector3 startPos = transform.position + new Vector3(0, 0.4f, 0);
        GameObject beam = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.0000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0 ,0);
            transform.position += Vector3.left * speed * Time.deltaTime;
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Restrict the player to screen
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D col) {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile) {
            Debug.Log("Ship Hit");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Die();
            }
        }
    }

    void Die() {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Win Screen");
        Destroy(gameObject);
        
    }
}
