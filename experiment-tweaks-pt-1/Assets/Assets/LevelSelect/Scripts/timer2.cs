using UnityEngine;
using System.Collections;

public class timer2 : MonoBehaviour {


    int score = 10000;
    // Use this for initialization
    void Start() {
        //PlayerPrefs.SetInt(Application.loadedLevel.ToString(), 1);
        PlayerPrefs.SetInt("Level3", 1);
        PlayerPrefs.SetInt("Level2_score", score);
        StartCoroutine(Time());

    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator Time() {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("LevelSelect");
    }


}
