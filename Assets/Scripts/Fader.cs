using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public float fadeTime = 1;

    public bool autoFadeOut = false;
    public float autoFadeOutDelay = 5;
    private Image fadePanel;

    private Color currentColor = Color.black;

    private void Awake() {
        fadePanel = GetComponent<Image>();
        // set color to black and full alpha before fade in
        currentColor.a = 1;
        fadePanel.color = currentColor;

    }

    // Use this for initialization
    void Start () {
        
        fadePanel.CrossFadeAlpha(0, fadeTime, false);
        
        if (autoFadeOut) {
            Invoke("FadeOut", autoFadeOutDelay);
        } else {
            Invoke("DisableFadePanel", fadeTime);
        }
	}

    void DisableFadePanel() {
        fadePanel.enabled = false;
    }

    void FadeOut() {
        /* fadeout is broken af, i cbf to fix it right now, wasting too much time
        print("fadeout called" + Time.time);
        fadePanel.enabled = true;
        currentColor.a = 0;
        fadePanel.color = currentColor;
        */
        fadePanel.CrossFadeAlpha( 1, fadeTime, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
