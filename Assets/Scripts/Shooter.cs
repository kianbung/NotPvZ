using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;

	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        // Get self's animator
        animator = GetComponent<Animator>();

        SetMyLaneSpawner();
        
	}

    private void Update() {
        if (AttackerAhead()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(projectile) as GameObject;
        bullet.transform.parent = projectileParent.transform;
        bullet.transform.position = gun.transform.position;
    }

    /* kena troll. this doesn't work unless sprite renderer is same gameobject as script
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    */

    bool AttackerAhead() {

        // Exit if lane spawner no children. Save CPU.
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        // Then start checking children to see if they're ahead of shooter
        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        // Attackers in lane, but behind shooter
        return false;
    }

    // Look through all spawners, and set myLaneSpawner if found
    void SetMyLaneSpawner() {

        //GameObject spawnerParent = GameObject.Find("Spawners");
        // set spawner array instead of relying on spawnerParent.transform to generate array, in case "Spawners" get changed

        AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray) {
            int spawnerY = (int) spawner.transform.position.y;
            int shooterY = (int) transform.position.y;

            if (spawnerY == shooterY) {
                myLaneSpawner = spawner;
                Debug.Log("Set " + myLaneSpawner + " as spawner for " + gameObject);
                return;
            }
        }

        // if no spawner found at all: 
        Debug.LogError("No lane spawner found for: " + gameObject);
    }
}
