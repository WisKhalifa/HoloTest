using System.Collections;
using System.Collections.Generic;
using HoloToolkitExtensions.Messaging;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuListener : MonoBehaviour {

	void Start () {
        Messenger.Instance.AddListener<MenuSelectedMessage>(ProcessMenuMessage);
	}
	
    private void ProcessMenuMessage(MenuSelectedMessage msg)
    {
        if (msg.MenuItem.MenuId == 1)
        {
            Debug.Log("you selected 1: " + msg.MenuItem.Title);
            
        }
        if (msg.MenuItem.MenuId == 2)
        {
            Debug.Log("you selected 2: " + msg.MenuItem.Title);
            SceneManager.LoadScene("ViewTestModel");
        }
        if (msg.MenuItem.MenuId == 3)
        {
            Debug.Log("you selected 3: " + msg.MenuItem.Title);
            SceneManager.LoadScene("Help");
        }
        if (msg.MenuItem.MenuId == 4)
        {
            Debug.Log("you selected 4: " + msg.MenuItem.Title);
            Quit();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
