using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMove : MonoBehaviour
{
    float angleH;
    float angleV;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetMouseButton(2)) { }
        else if (Input.GetMouseButton(2))
        {
            angleH += Input.GetAxis("Mouse X");
            angleV += Input.GetAxis("Mouse Y");
            Vector3 moveForward = Camera.main.transform.up * angleV + Camera.main.transform.right * angleH;
            moveForward.y = 0;
            Vector3 newPos = transform.position + moveForward / 90f;
            transform.position = newPos;
        }
        else
        {
            angleH = 0f;
            angleV = 0f;
        }

    }

}