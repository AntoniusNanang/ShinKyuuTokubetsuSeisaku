﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMove : MonoBehaviour
{
    float angleH;
    float angleV;
    static public Vector3 centerPos;
    void Start()
    {
        Invoke("pos", 0.001f);
    }

    void Update()
    {

        if (Input.GetMouseButton(2) && !Input.GetKey(KeyCode.Space))
        {
            angleH = Input.GetAxis("Mouse X");
            angleV = Input.GetAxis("Mouse Y");
            Vector3 moveForward = Camera.main.transform.up * -angleV + Camera.main.transform.right * -angleH;
            //moveForward.y = 0;
            Vector3 newPos = transform.position + moveForward / 2.0f;
            transform.position = newPos;
        }
        else
        {
            angleH = 0f;
            angleV = 0f;
        }

    }

    void pos()
    {
        transform.position = centerPos;
    }

}