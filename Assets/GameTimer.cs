using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Survive for x seconds.")]
    public float timeToSurvive = 60;
    //private float timeLeft; <-- unnecessary since we use Time.timeSinceLevelLoad
    Slider timeSlider;
    public AudioClip winSound;

    private bool won = false;

	// Use this for initialization
	void Start () {
        //timeLeft = timeToSurvive;
        timeSlider = GetComponent<Slider>();
        UpdateSlider();
	}
	
	// Update is called once per frame
	void Update () {
        //timeLeft -= Time.deltaTime;
        UpdateSlider();
        WinCheck();
	}

    void UpdateSlider() {
        
        float timePercent = Time.timeSinceLevelLoad / timeToSurvive;
        timeSlider.value = timePercent;
    }

    void WinCheck() {
        if (timeSlider.value >= 1 && !won) {
            Time.timeScale = 0;
            GameObject winText = GameObject.Find("YouWinText");
            GameObject nextLevelButton = GameObject.Find("NextLevelButton");
            winText.GetComponent<Text>().enabled = true;
            nextLevelButton.GetComponent<Text>().enabled = true;

            // I kaypo. but can also create from inspector and attach to slider to make it easy
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = winSound;
            audioSource.volume = PlayerPrefsManager.GetMasterVolume();
            audioSource.Play();
            won = true;
        }
    }
}
