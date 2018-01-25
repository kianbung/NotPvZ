using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

    // Use this for initialization
    void Start () {

        // Declare Components
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.GetComponent<Defender>()) {
            return;
        }

        if (collision.gameObject.tag == "canJumpOver") {
            animator.SetTrigger("Jump");
        } else {
            attacker.Attack(collision.gameObject);
            animator.SetBool("isAttacking", true);
        }
    }
}
