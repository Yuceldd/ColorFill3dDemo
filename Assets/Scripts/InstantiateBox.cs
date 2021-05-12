using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InstantiateBox : MonoBehaviour
{
    public float width;
    public float width2;
    public GameObject Aimbox;

    void Start()
    {
        for (float x = -width; x <= width; x++)
        {
            for (float z = -width2; z <= width2; z++)
            {
                Instantiate(Aimbox, new Vector3(x, -0.49f, z), Quaternion.identity);
            }
        }
    }
}