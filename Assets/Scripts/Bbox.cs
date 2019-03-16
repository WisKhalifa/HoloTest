using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bbox : MonoBehaviour, IFocusable {

    Material BboxMat;
    GameObject SRSBBox;
    Bounds SRSBounds;
    bool isActive;
    public bool BboxCreated;
    public bool isRootObject;

    public void OnFocusEnter()
    {
        if (!BboxCreated)
        {
            return;
        }
        if (isActive)
        {
            return;
        }
        NRSRManager.SendFocusedObjectToManager(gameObject);

        isActive = true;
    }

    public void OnFocusExit()
    {
        if (!BboxCreated)
        {
            return;
        }
        if (!isActive)
        {
            return;
        }
        NRSRManager.ClearFocusedObjectFromManager();
        isActive = false;
    }

    // Use this for initialization
    void Start () {
        BboxMat = NRSRManager.Instance.BboxMat;
	}
	
	// Update is called once per frame
	void Update () {
		if (!BboxCreated && isRootObject)
        {
            CreateBbox();
            BboxCreated = true;
            return;
        }

        if (SRSBBox != null)
        {
            if (!isActive)
            {
                SRSBBox.SetActive(false);
                return;
            }
            if (isActive)
            {
                SRSBBox.SetActive(true);
            }
        }
	}


    void CreateBbox()
    {
        SRSBBox = Instantiate(gameObject);
        SRSBBox.name = "BoundingBox";

        if (SRSBBox.GetComponent<Bbox>() == null)
        {
            Destroy(SRSBBox);
            return;
        }
        else
        {
            Destroy(SRSBBox.GetComponent<Bbox>());
            SRSBBox.tag = "NRSRTools";
            SRSBBox.transform.localScale *= 1.1f;
            SRSBBox.transform.parent = gameObject.transform;

            List<Transform> children = new List<Transform>(SRSBBox.GetComponentsInChildren<Transform>());
            Debug.Log("Children");

            foreach (Transform child in children)
            {
                child.tag = "NRSRTools";
                if (child.GetComponent<MeshRenderer>() != null)
                {
                    Debug.Log("yes!");
                    child.GetComponent<MeshRenderer>().material = BboxMat;
                    child.transform.parent = SRSBBox.transform;
                }
            }
        }

        List<MeshFilter> childrenBounds = new List<MeshFilter>(SRSBBox.GetComponentsInChildren<MeshFilter>());
        foreach(MeshFilter meshRen in childrenBounds)
        {
            if (meshRen.GetComponent<MeshFilter>() != null)
            {
                Debug.Log(meshRen.gameObject.name);
                SRSBounds.Encapsulate(meshRen.GetComponent<MeshFilter>().mesh.bounds);
            }
        }

        Vector3 SRSPoint0 = SRSBounds.min * gameObject.transform.localScale.x * 1.1f;
        Vector3 SRSPoint1 = SRSBounds.max * gameObject.transform.localScale.z * 1.1f;
        Vector3 SRSPoint2 = new Vector3(SRSPoint0.x, SRSPoint0.y, SRSPoint1.z);
        Vector3 SRSPoint3 = new Vector3(SRSPoint0.x, SRSPoint1.y, SRSPoint0.z);
        Vector3 SRSPoint4 = new Vector3(SRSPoint1.x, SRSPoint0.y, SRSPoint0.z);
        Vector3 SRSPoint5 = new Vector3(SRSPoint0.x, SRSPoint1.y, SRSPoint1.z);
        Vector3 SRSPoint6 = new Vector3(SRSPoint1.x, SRSPoint0.y, SRSPoint1.z);
        Vector3 SRSPoint7 = new Vector3(SRSPoint1.x, SRSPoint1.y, SRSPoint0.z);

        CreateEndPoints(SRSPoint0 + transform.position);
        CreateEndPoints(SRSPoint1 + transform.position);
        CreateEndPoints(SRSPoint2 + transform.position);
        CreateEndPoints(SRSPoint3 + transform.position);
        CreateEndPoints(SRSPoint4 + transform.position);
        CreateEndPoints(SRSPoint5 + transform.position);
        CreateEndPoints(SRSPoint6 + transform.position);
        CreateEndPoints(SRSPoint7 + transform.position);

    }

    void CreateEndPoints(Vector3 position)
    {
        GameObject CornerHandle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        CornerHandle.name = "Handle";
        CornerHandle.tag = "NRSRTools";

        //Scale
        CornerHandle.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        //Position
        CornerHandle.transform.position = position;
        //Parent
        CornerHandle.transform.parent = SRSBBox.transform;
        //Material
        CornerHandle.GetComponent<Renderer>().material = BboxMat;
    }

    
}
