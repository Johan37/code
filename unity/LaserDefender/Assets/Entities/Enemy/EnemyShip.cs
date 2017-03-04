using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float health = 200f;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile) {
            Debug.Log("Ship Hit");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        InvokeRepeating("Fire", 0.0000001f, fireRate);
    }

    void Fire() {
        Vector3 startPos = transform.position + new Vector3(0,-1, 0);
        GameObject beam = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }
}
