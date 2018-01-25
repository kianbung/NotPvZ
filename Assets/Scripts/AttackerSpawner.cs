using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerArray;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject thisAttacker in attackerArray) {
           
            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    public void Spawn(GameObject spawn) {
        // seriously, why "as GameObject"?? 
        GameObject newSpawn = Instantiate(spawn, transform.position, Quaternion.identity);
        newSpawn.transform.parent = transform;
    }

    // alt solution for spawncheck given by teacher
    bool isTimeToSpawn(GameObject thisAttacker) {
        
        // kimak, ended up using probability anyway
        Attacker atk = thisAttacker.GetComponent<Attacker>();
        float meanSpawnDelay = atk.seenEverySeconds;
        float spawnPerSecond = 1 / meanSpawnDelay; // atk.seenEverySeconds;
        float probability = (Time.deltaTime * spawnPerSecond) / 5;

        if (Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawnrate capped by framerate.");
        }

        // returns true or false like this
        return (Random.value < probability);
    }
}
