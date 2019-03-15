using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class InteractiveCube : MonoBehaviour, IFocusable, IInputClickHandler {

    public bool Rotating;
    public float RotationSpeed;
    public Vector3 ScaleChange;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the cube around the y-axis at one degree per second multiplied by the speed
		if (Rotating)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        }
	}

    // On cube focus set rotate to true
    public void OnFocusEnter()
    {
        Rotating = true;
    }
    
    // On cube out of focus set rotate to false
    public void OnFocusExit()
    {
        Rotating = false;
    }

    // Cube increases in scale when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        transform.localScale += ScaleChange;
    }
}
