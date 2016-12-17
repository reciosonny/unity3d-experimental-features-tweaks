using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class timer : MonoBehaviour {

    int score = 3000;
	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetInt(Application.loadedLevel.ToString(), 1);
        PlayerPrefs.SetInt("Level2", 1);
        PlayerPrefs.SetInt("Level1_score", score);
        StartCoroutine(Time());

    }

    // Update is called once per frame
    void Update () {
	    
	}

    IEnumerator Time() {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("LevelSelect");
    }

}
