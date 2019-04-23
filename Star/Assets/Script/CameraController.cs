using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject centerObj;
    Vector3 startPos;
    Vector3 startPosC;
    Quaternion startRote;
    float LastX;
    float LastY;
    static public float camera_z = -50;

    void Start()
    {
        transform.position = new Vector3(0, 0, camera_z);
        centerObj = GameObject.Find("Center");
        Invoke("startpos", 0.1f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetMouseButton(2))
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");

            if (mouseInputX < -5.0f) mouseInputX = -5.0f;
            else if (mouseInputX > 5.0f) mouseInputX = 5.0f;

            if (mouseInputY < -5.0f) mouseInputY = -5.0f;
            else if (mouseInputY > 5.0f) mouseInputY = 5.0f;
            
            LastX = mouseInputX;
            LastY = mouseInputY;
            transform.RotateAround(centerObj.transform.position, transform.up, mouseInputX * Time.deltaTime * 400f);
            transform.RotateAround(centerObj.transform.position, transform.right, mouseInputY * Time.deltaTime * 400f);
        }

        if (LastX > 0.0f)
        {
            LastX -= 0.01f;
            if (LastX < 0.0f)
            {
                LastX = 0.0f;
            }
        }
        else if (LastX < 0.0f)
        {
            LastX += 0.01f;
            if (LastX > 0.0f)
            {
                LastX = 0.0f;
            }
        }
        transform.RotateAround(centerObj.transform.position, transform.up, LastX * Time.deltaTime * 400f);


        if (LastY > 0.0f)
        {
            LastY -= 0.01f;
            if (LastY < 0)
            {
                LastY = 0.0f;
            }
        }
        else if (LastY < 0.0f)
        {
            LastY += 0.01f;
            if (LastY > 0)
            {
                LastY = 0.0f;
            }
        }
        transform.RotateAround(centerObj.transform.position, transform.right, LastY * Time.deltaTime * 400f);


        if (Input.GetKeyDown(KeyCode.R))
        {
            CameraReset();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 3;
    }

    public void startpos()
    {
        startPosC = centerObj.transform.position;
        startPos = transform.position;
        startRote = transform.rotation;
    }

    public void CameraReset()
    {
        LastX = 0;
        LastY = 0;
        centerObj.transform.position = startPosC;
        transform.position = startPos;
        transform.rotation = startRote;
    }
}
