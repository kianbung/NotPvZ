using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButtons : MonoBehaviour {

    private DefenderButtons[] buttonArray;
    public GameObject spawnsDefender;
    public static GameObject selectedDefender;

    private Text costText;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = Color.black;
        // search all possible Defender buttons as array
        buttonArray = GameObject.FindObjectsOfType<DefenderButtons>();

        // set text to child text component
        costText = gameObject.GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogWarning(gameObject.name + " has no costText");
        }

        // display text string based on star cost of linked spawnsDefender object
        costText.text = spawnsDefender.gameObject.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        // turn all buttons parent black
        foreach (DefenderButtons thisButton in buttonArray) {
            SpriteRenderer spriteRenderer = thisButton.GetComponent<SpriteRenderer>();
            if (spriteRenderer) {
                spriteRenderer.color = Color.black;
            }
        }
        // turn current button white (visible)
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = spawnsDefender;
    }
}
