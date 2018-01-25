using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarCount : MonoBehaviour {

    public static int starcount;
    Text displayText;

    public enum Status {SUCCESS, FAILURE};

    private void Start() {
        displayText = GetComponent<Text>();
        starcount = 0;
        UpdateDisplay();
    }

    public void AddStars(int stars) {
        starcount += stars;
        UpdateDisplay();
    }

    public Status UseStars(int stars) {
        if (starcount >= stars) {
            starcount -= stars;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }

    void UpdateDisplay() {
        displayText.text = starcount.ToString();
    }
}
