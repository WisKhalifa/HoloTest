using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoWindow : MonoBehaviour
{

    public GameObject infoWindow;
    private GameObject nodeTitle;
    private bool showing = false;
    public Quaternion DefaultRotation { get; private set; }

    private void Awake()
    {
        DefaultRotation = gameObject.transform.rotation;
        nodeTitle = gameObject.transform.Find("NodeTitle").gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 directionToTarget = Camera.main.transform.position - gameObject.transform.position;
        directionToTarget.y = gameObject.transform.position.y - 0.05f;
        gameObject.transform.rotation = Quaternion.LookRotation(-directionToTarget) * DefaultRotation;
    }

    private void OnTapped()
    {
        if (showing)
        {
            infoWindow.SetActive(false);
            nodeTitle.SetActive(true);
            showing = false;
            this.BroadcastMessage("ShowTitle");
        }
        else
        {
            infoWindow.SetActive(true);
            nodeTitle.SetActive(false);
            this.BroadcastMessage("HideTitle");
            showing = true;
        }

    }
}