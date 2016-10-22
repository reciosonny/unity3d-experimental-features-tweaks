using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SwordPersistence : MonoBehaviour {

    void OnGUI() {
        //GUI.Button(new Rect(10, 220, 100, 30), "Experience down");
        //GUI.Label(new Rect(10, 220, 100, 30), "Test");
        GUI.Box(new Rect(10, 220, 100, 30), "Test");
        //GetComponent<Image>

    }

    // Use this for initialization
    void Start () {
        //TODO: finish implementation of data persistence by storing sword information data to binary file and deserialize it to retrieve data for display by cloning panel component
        var component = gameObject.GetComponentInChildren<Image>();
        var position = component.transform.position;
        
        var clonedComponent = Instantiate(component); //problem with cloned component: incorrect width/height
        clonedComponent.rectTransform.position = component.rectTransform.position;
        clonedComponent.rectTransform.sizeDelta = component.rectTransform.sizeDelta;
        clonedComponent.transform.parent = gameObject.transform;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

[Serializable]
class Sword {
    public string Name { get; set; }
    public double Damage { get; set; }
    public double Durability { get; set; }
    public string SpecialSkill { get; set; }
}