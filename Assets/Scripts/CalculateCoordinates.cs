using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCoordinates : MonoBehaviour
{

    public float radius;
    public float polar;
    public float elevation;

    void Awake()
    {
        Vector3 sphereLocation = SphericalToCartesian(radius, polar, elevation);
        transform.position = sphereLocation;
    }

    // Use this for initialization
    void Start()
    {

    }

    public static Vector3 SphericalToCartesian(float radius, float polar, float elevation)
    {
        // convert to radians
        polar = (float)(polar * (Math.PI / 180.0));
        elevation = (float)(elevation * (Math.PI / 180.0));

        Vector3 cartesianCoords = new Vector3();

        float a = radius * Mathf.Cos(elevation);
        cartesianCoords.x = a * Mathf.Cos(polar);
        cartesianCoords.y = radius * Mathf.Sin(elevation);
        cartesianCoords.z = (a * Mathf.Sin(polar) + 0.9f);

        return cartesianCoords;
    }

}