using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNodeOnSelect : MonoBehaviour
{
    private Color originalColor;
    public GameObject nodeTitle;
    private bool showingTitle = true;
    void Start()
    {
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    void HideTitle()
    {
        showingTitle = false;
    }

    void ShowTitle()
    {
        showingTitle = true;
    }

    private void OnSelect()
    {
        var node = this.GetComponent<Renderer>();
        var color = node.material.color;
        var brigherColor = new Color(color.r * 1.25f, color.g * 1.25f, color.b * 1.25f, color.a);

        node.material.color = brigherColor;

        if (showingTitle)
        {
            nodeTitle.SetActive(true);
        }

    }

    private void OnReset()
    {
        var node = this.GetComponent<Renderer>();
        node.material.color = originalColor;

        nodeTitle.SetActive(false);
    }


}
