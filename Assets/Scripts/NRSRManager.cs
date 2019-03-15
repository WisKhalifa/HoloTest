using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRSRManager : Singleton<NRSRManager> {

    public Renderer[] ObjectsInScene;
    public List<GameObject> FilterObjectsInScene = new List<GameObject>();

    public int TotalNumberOfObjects = 0;
    public int PreviousFrameObjectCount = 0;

    public int numberOfVisibleObjects;
    public int numberOfFilteredObjects;

    public Material BboxMat;

    void FixedUpdate()
    {
        FindObjectsInScene();

        TotalNumberOfObjects = ObjectsInScene.Length;

        if (TotalNumberOfObjects != PreviousFrameObjectCount)
        {
            FilterUnneededObjects();
            numberOfVisibleObjects = FilterObjectsInScene.Count;

            foreach(GameObject go in FilterObjectsInScene)
            {
                if (go.transform.root.gameObject.GetComponent<Bbox>() == null)
                {
                    Bbox box = go.transform.root.gameObject.AddComponent<Bbox>();
                    box.isRootObject = true;
                }
            }
        }
        PreviousFrameObjectCount = ObjectsInScene.Length;

    }

    void FindObjectsInScene()
    {
        ObjectsInScene = null;
        ObjectsInScene = FindObjectsOfType<Renderer>();
    }

    void FilterUnneededObjects()
    {
        FilterObjectsInScene.Clear();
        numberOfFilteredObjects = 0;

        for(int i = 0; i < ObjectsInScene.Length; i++)
        {
            if (ObjectsInScene[i].gameObject.tag != "NRSRTools")
            {
                FilterObjectsInScene.Add(ObjectsInScene[i].gameObject);
            }
            else
            {
                numberOfFilteredObjects++;
            }
        }
    }
}
