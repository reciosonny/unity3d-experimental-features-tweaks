using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class LevelManagerNew : MonoBehaviour {

    [Serializable]
    public class Level {
        public string LevelText;
        public int Unlocked;
        public bool IsInteractable;

        //public Button.ButtonClickedEvent OnClickEvent;
    }

    public GameObject levelButton;
    public Transform Spacer;
    public List<Level> LevelList;

    // Use this for initialization
    void Start () {
        FillList();
        //DeleteAll();
    }
	
    void FillList() {
        foreach (var level in LevelList) {
            GameObject newbutton = Instantiate(levelButton) as GameObject;
            LevelButtonNew button = newbutton.GetComponent<LevelButtonNew>();
            button.LevelText.text = level.LevelText;
            
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1) { //level 1 will always be unlocked
                level.Unlocked = 1;
                level.IsInteractable = true;
            }
            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels("Level" + button.LevelText.text));

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 0) {
                button.Star1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 5000) {
                button.Star2.SetActive(true);
            }
            if (PlayerPrefs.GetInt(string.Format("Level{0}_score", button.LevelText.text )) >= 9999) {
                button.Star3.SetActive(true);
            }

            button.transform.SetParent(Spacer);
        }
        //SaveAll();
    }

    void SaveAll() {

        //if (PlayerPrefs.HasKey("Level1")) {
        //    return;
        //}
        //else 
        {
            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");

            foreach (GameObject item in allButtons) {
                LevelButtonNew button = item.GetComponent<LevelButtonNew>();
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
            }
        }
    }

    void DeleteAll() {
        PlayerPrefs.DeleteAll();
    }

    void loadLevels(string value) {
        SceneManager.LoadScene(value);
    }



}
