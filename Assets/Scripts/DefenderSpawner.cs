using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;
    private StarCount starCounter;

	// Use this for initialization
	void Start () {
        starCounter = GameObject.FindObjectOfType<StarCount>();

        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }
	}

	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        

        int defenderCost = DefenderButtons.selectedDefender.GetComponent<Defender>().starCost;
        if (starCounter.UseStars(defenderCost) == StarCount.Status.SUCCESS) {
            SpawnDefender();
            
        } else {
            // NEED TO GIVE PLAYER FEEDBACK FOR LACK OF CURRENCY
            Debug.Log("Not enough Stars to buy.");
        }

        
    }

    void SpawnDefender() {
        Vector2 worldPoints = TranslateMousePositionToWorldPoints();
        Vector2 snappedPoints = SnapToGrid(worldPoints);
        // why is "as GameObject" necessary??
        GameObject newSpawn = Instantiate(DefenderButtons.selectedDefender, snappedPoints, Quaternion.identity);
        newSpawn.transform.parent = defenderParent.transform;
    }

    Vector2 TranslateMousePositionToWorldPoints() {
        Vector2 worldPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return worldPoints;
    }

    Vector2 SnapToGrid(Vector2 rawPoints) {

        // Possible rounding problem from edges
        int newX = Mathf.RoundToInt(rawPoints.x);
        int newY = Mathf.RoundToInt(rawPoints.y);

        newX = Mathf.Clamp(newX, 1, 9);
        newY = Mathf.Clamp(newY, 1, 5);

        return new Vector2(newX, newY);
    }
}
