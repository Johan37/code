using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float health = 200f;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;

    public int scoreValue =150;
    private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

    void OnTriggerEnter2D(Collider2D col) {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile) {
            Debug.Log("Ship Hit");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * fireRate;
        if (Random.value < probability) {
            Fire();
        }
    }

    void Fire() {
        Vector3 startPos = transform.position + new Vector3(0,-1, 0);
        GameObject beam = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }
}
