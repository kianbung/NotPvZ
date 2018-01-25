using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;
    public AudioClip[] gameMusic;
    private AudioSource audioSource;
    private AudioClip playingMusic;

    void Awake() {
        // Gotta define audioSource early, else error 
        audioSource = GetComponent<AudioSource>();

        // Debug.Log("Music Awake: " + GetInstanceID());

        // Check if MusicPlayer exists. If it does, destroy new spawn. If new, make persistent.
        // also check to make sure we don't destroy ourselves
        if (instance != null && instance != this) {
            Destroy(gameObject);
            //Debug.Log("Dupe Music Destruct: " + GetInstanceID());
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        // initialise with saved volume
        // added in check for existence of value, else (maybe) will set to zero on first start
        if (PlayerPrefsManager.MasterVolumeExists() == false) {
            // bad practice setting difficulty in the music manager, but i guess i'll use it as an init script here
            PlayerPrefsManager.SetDifficulty(2);
            PlayerPrefsManager.SetMasterVolume(0.5f);
            Debug.Log("First time run. Setting default volume and difficulty prefs.");
        }
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();

    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }


    // Adding (and removing on disable) OnSceneLoaded() as delegate to SceneManager.sceneLoaded
    // alternatively: SceneManager.activeSceneChanged
    // have also confirmed that previous scenes are unloaded when the new one is loaded, so it doesn't really matter at this level
    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //this triggers on scene change
    void OnSceneLoaded(Scene currentScene, LoadSceneMode loadSceneMode) {
        // kaypo make additional references. I don't even know if it's a good idea.
        int currentSceneIndex = currentScene.buildIndex;
        AudioClip levelMusic = gameMusic[currentSceneIndex];

        // if level's music is defined && is not currently set as playing music
        if (levelMusic && playingMusic != levelMusic) {
            // play audioclip based on array, using scene index
            audioSource.clip = levelMusic;
            audioSource.Play();
            // set current playing music
            playingMusic = levelMusic;
        }
        
    }
}
