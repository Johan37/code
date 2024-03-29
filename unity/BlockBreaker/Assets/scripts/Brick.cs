﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;

    public static int breakableCount = 0;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }

		timesHit= 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

	}

	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }
    
    void HandleHits() {
        timesHit++;
        int maxHit = hitSprites.Length + 1;
        if (timesHit >= maxHit ) {
            breakableCount--;
            GameObject smokePuff = Instantiate(smoke, transform.position,
                    Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = 
                gameObject.GetComponent<SpriteRenderer>().color;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        } 
        else {
            LoadSprites();
        }
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] ) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Brick sprite missing");
        }
    }

}
