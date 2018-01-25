using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, difficultySlider; // ooh, can declare multiple in one line
    //public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
        // for music player
        musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        if (PlayerPrefsManager.MasterVolumeExists()) {
            volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
            Debug.Log(musicPlayer);
            difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        } else {
            SetDefaults();
            PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
            PlayerPrefsManager.SetDifficulty((int) difficultySlider.value);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        musicPlayer.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndBack() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty((int) difficultySlider.value); // (int) because slider values are auto float
        levelManager.LoadLevel("01 Start");
    }

    public void SetDefaults() {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2;
    }

    public void NukeKeys() {
        PlayerPrefsManager.NukeKeys();
    }
}
