using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalCube : MonoBehaviour
{
    public GameObject Redcube;
    public float rotationSpeed = 2.0f;
    public float x;
    public float z;

    void Start()
    {
        Redcube = Instantiate(Redcube, new Vector3(x, 0.5f, z), Quaternion.identity);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed, rotationSpeed, rotationSpeed);
    }
}