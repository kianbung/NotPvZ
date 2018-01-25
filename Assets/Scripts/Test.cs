using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Difficulty: " +PlayerPrefsManager.GetDifficulty());
        float x = 34.41f;
        float y = 100;
        print(x * y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
