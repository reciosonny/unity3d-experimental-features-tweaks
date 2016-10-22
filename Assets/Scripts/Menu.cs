using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas mainCanvas;
    public Canvas optionsCanvas;
    
	// Use this for initialization
	void Start () {
        optionsCanvas.enabled = false;
	}
	
	public void OptionsOn() {
        optionsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }

    public void ReturnOn() {
        optionsCanvas.enabled = false;
        mainCanvas.enabled = true;
    }

    public void LoadOn() {
        SceneManager.LoadScene(1);
    }


}
