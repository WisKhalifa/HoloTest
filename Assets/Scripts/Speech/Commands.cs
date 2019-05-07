using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Commands : MonoBehaviour {
    private Vector3 originalPosition;
    
    // Use this for initialization
    void Start () {
        originalPosition = this.transform.localPosition;
        
	}

    void OnReset()
    {
        this.transform.localPosition = originalPosition;
    }
    void OnMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    void OnTestModels()
    {
        SceneManager.LoadScene("ViewTestModel");
    }
    void OnHelp()
    {
        SceneManager.LoadScene("Help");
    }
    void OnCreateGraph()
    {
        SceneManager.LoadScene("CreateGraph");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
