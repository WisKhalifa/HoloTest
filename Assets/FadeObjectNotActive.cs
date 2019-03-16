using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjectNotActive : MonoBehaviour {

    private void OnEnable()
    {
        NRSRManager.ObjectFocused += FadeObject;
        NRSRManager.ObjectUnFocused += UnFadeObject;
    }

    private void OnDisable()
    {
        NRSRManager.ObjectFocused -= FadeObject;
        NRSRManager.ObjectUnFocused -= UnFadeObject;
    }

    void FadeObject()
    {
        if (gameObject.tag == "NRSRTools") { return;  }

        Debug.Log(gameObject.name + " should fade");
    }

    void UnFadeObject()
    {
        if (gameObject.tag == "NRSRTools") { return;  }

        Debug.Log(gameObject.name + " should unfade");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
