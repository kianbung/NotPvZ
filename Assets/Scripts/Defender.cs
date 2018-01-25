using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    private StarCount starCounter;
    public int starCost = 1;

	// Use this for initialization
	void Start () {
        starCounter = GameObject.FindObjectOfType<StarCount>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddStars(int stars) {
        starCounter.AddStars(stars);
    }
}
