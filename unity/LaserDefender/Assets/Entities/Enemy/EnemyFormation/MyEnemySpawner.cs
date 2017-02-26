using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;

    public float formationWidth;
    public float formationHeight;

    public float speed;
    public float padding;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject; 
            enemy.transform.parent = child;
        }

        // Calculating world boundries
        float distance = transform.position.z - Camera.main.transform.position.z;
    	Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0 ,distance));
    	Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0 ,distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(formationWidth, formationHeight, 0));
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed * Time.deltaTime, 0 ,0);

        float rightEdgeOfFormation = transform.position.x - 0.5f * formationWidth; 
        float leftEdgeOfFormation = transform.position.x + 0.5f * formationWidth; 
        if (leftEdgeOfFormation <= xmin || rightEdgeOfFormation >= xmax ) {
            speed = speed * -1;
        }

	}
}
