using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTap : MonoBehaviour, IInputClickHandler
{

    private bool showing = false;
    public GameObject infoWindow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (showing)
        {
            infoWindow.SetActive(false);
            showing = false;
        }
        else
        {
            infoWindow.SetActive(true);
            showing = true;
        }
    }
}
