using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        levelManager.LoadLevel("03b Lose");
    }
}
