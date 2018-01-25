using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Range(0, 3)]
    public float moveSpeed = 1;
    private float moveMod = 1;

    public float damage = 1;
    [Tooltip("Appears every x seconds")]
    public float seenEverySeconds;

    private GameObject currentTarget;

	// Use this for initialization
	void Start () {
        // add rigidbody2d via script so can lazy with adding via editor. lel.
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;

        

    }
	
	// Update is called once per frame
	void Update () {
        // movement speed * modifier speed
        transform.Translate(Vector2.left * moveSpeed * moveMod * Time.deltaTime);

        // target exists?
        if (!currentTarget) {
            gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
        }
        

    }

    void HitCurrentTarget() {
        if (currentTarget) {
            currentTarget.GetComponent<HP>().DamageHP(damage);
        }
        
    }

    // use for animator only. unity animator retarded can't accept bool args
    void MoveMod(float newMod) {
        moveMod = newMod;
    }

    // change target of attack
    public void Attack(GameObject target) {
        currentTarget = target;
    }

}
