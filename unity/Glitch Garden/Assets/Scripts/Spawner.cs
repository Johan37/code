using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	void Start () {
    }
	
	void Update () {
        Debug.Log("Update");
        foreach ( GameObject thisAttacker in attackerPrefabArray) {
            Debug.Log("Loop");
            if (isTimeToSpawn( thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    private bool isTimeToSpawn( GameObject prefab) {
        Attacker attacker = prefab.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5 ;

        if (Random.value < threshold) {
            return true;
        }
        else {
            return false;
        }
    }

    private void Spawn(GameObject prefab) {
        Debug.Log("Spawn");
        GameObject myGameObject = Instantiate(prefab) as GameObject;
        myGameObject.transform.position = transform.position;
        myGameObject.transform.parent = transform;
    }
}
