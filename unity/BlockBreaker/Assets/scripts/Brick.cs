using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int maxHit;
    private int timesHit;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit= 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision) {
        timesHit++;
        SimulateWin();
    }

    // TODO Remove when we can actually win
    void SimulateWin() {
        levelManager.LoadNextLevel(); 
    }
}
