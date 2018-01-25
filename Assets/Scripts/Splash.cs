using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public float splashTimer = 6;

	// Use this for initialization
	void Start () {
        Invoke("StartGame", splashTimer);
	}

    void StartGame() {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            StartGame();
        }
	}
}
