using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker) {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
