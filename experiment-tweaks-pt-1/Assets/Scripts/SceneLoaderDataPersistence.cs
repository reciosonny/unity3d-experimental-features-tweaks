using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoaderDataPersistence : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene1() {
        SceneManager.LoadScene("Data-Persistence-Scene1");
    }
    public void LoadScene2() {
        SceneManager.LoadScene("Data-Persistence-Scene2");
    }

}
