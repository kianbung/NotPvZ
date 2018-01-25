using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    public float hp = 2;

    void Death() {

        /* Potentially fast cheat for easy death animation
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody2D) {
            rigidbody2D.isKinematic = false;
        } else {
            Destroy(gameObject);

        }
        */
        Destroy(gameObject);
    }

    public void DamageHP(float damage) {
        hp -= damage;
        if (hp <= 0) {
            // trigger animation here optionally
            Death();
        }
    }
}
