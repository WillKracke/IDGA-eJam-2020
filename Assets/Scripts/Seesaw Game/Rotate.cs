﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Variables
    // This should be a value between -10 -> 10
    public float rotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotValue = new Vector3(0, 0, rotation);
        this.gameObject.transform.rotation = Quaternion.Euler(rotValue);
    }

    // Method for rotating the object
    public void rotate(float value)
    {
        rotation = value;
    }
}