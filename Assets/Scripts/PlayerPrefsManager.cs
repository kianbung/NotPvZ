using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void NukeKeys() {
        PlayerPrefs.DeleteAll();
        Debug.LogWarning("All PlayerPrefs keys nuked.");
    }

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range: " + volume);
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static bool MasterVolumeExists() {
        return PlayerPrefs.HasKey(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true (unity playerprefs no bools)
        } else {
            Debug.LogError("Trying to unlock level not in build order: " + level);
        }
    }

    /* My working solution. But teacher gave a more elegant solution (see below comment block)
    public static bool IsLevelUnlocked( int level ) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            string levelKeyString = LEVEL_KEY + level.ToString();
            if (PlayerPrefs.HasKey(levelKeyString)) {
                Debug.Log("Key exists: " + levelKeyString);
                if (PlayerPrefs.GetInt(levelKeyString) == 1) {
                    Debug.Log("Level is unlocked: " + level);
                    return true;
                } else {
                    Debug.LogError("Key exists, unlock value is other than 1. Found value: " + PlayerPrefs.GetInt(levelKeyString));
                }
            } else {
                Debug.Log("Key does not exist: " + levelKeyString);
            }
        } else {
            Debug.LogError("Trying to check for unlocked level outside build order: " + level);
        }
        return false;
    }
    */

    public static bool IsLevelUnlocked(int level) {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            return isLevelUnlocked;
        } else {
            Debug.LogError("Trying to query for unlocked level outside build order: " + level);
            return false;
        }
    }

    public static void SetDifficulty(int difficulty) {
        if (difficulty >= 1 && difficulty <= 3) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.LogError("Difficulty outside accepted range: " + difficulty);
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
