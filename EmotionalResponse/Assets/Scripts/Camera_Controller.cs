﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float minY = -50f;
    public float maxY = 50f;
    public float rotateSpeed;
    float rotate;
    //public float smoothing;

    Vector2 PrevMousePos = Vector2.zero;
    float RotY, RotX = 0f;

    public Transform Head;
    
    void Start ()
    {
        
    }
	
	void Update ()
    {
        Vector2 MouseDelta = (Vector2)Input.mousePosition - PrevMousePos;
        RotY += MouseDelta.x;
        if (RotX + (-MouseDelta.y) * rotateSpeed < maxY & RotX + (-MouseDelta.y) * rotateSpeed > minY) // If in bounds
        {
            RotX += (-MouseDelta.y)*rotateSpeed;
        }
        //Debug.Log("RotX = " + RotX);
        transform.rotation = Quaternion.Euler(RotX, RotY, 0f);

        PrevMousePos = Input.mousePosition;
    }
}
