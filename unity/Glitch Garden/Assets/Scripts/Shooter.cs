using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner mySpawner;

    private void Start() {
        animator = GameObject.FindObjectOfType<Animator>();
        SetMyLaneSpawner();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update() {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetMyLaneSpawner() {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach ( Spawner spawner in spawners) {
            if (spawner.transform.position.y == transform.position.y) {
                mySpawner = spawner;
                return;
            }
        }
        Debug.LogError("No spawner found for Shooter in lane " + transform.position.y);
    }

    private bool IsAttackerAheadInLane() {
        // Exit if no attackers in lane
        if (mySpawner.transform.childCount <= 0) {
            return false;
        }

        foreach (Transform attacker in mySpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        // No Attackers ahead
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
