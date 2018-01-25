﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Attacker>()) {
            collision.gameObject.GetComponent<HP>().DamageHP(damage);
            Destroy(gameObject);
        }
    }
}
