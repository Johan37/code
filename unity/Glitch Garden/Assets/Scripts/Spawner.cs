using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	void Start () {
    }
	
	void Update () {
        foreach ( GameObject thisAttacker in attackerPrefabArray) {
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

        return (Random.value < threshold);
    }

    private void Spawn(GameObject prefab) {
        GameObject myGameObject = Instantiate(prefab) as GameObject;
        myGameObject.transform.position = transform.position;
        myGameObject.transform.parent = transform;
    }
}
