using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject targetObj;
    GameObject centerObj;
    Vector3 startPos;
    Vector3 startPosC;
    Quaternion startRote;
    Vector3 targetPos;
    float camera_z = -50;
    void Start()
    {
        transform.position = new Vector3(0, 0, camera_z);
        targetObj = GameObject.Find("target");
        centerObj = GameObject.Find("Center");
        startPosC = centerObj.transform.position;
        startPos = transform.position;
        startRote = transform.rotation;
    }

    void Update()
    {
        targetPos = targetObj.transform.position;
        if (Input.GetKey(KeyCode.Space) && Input.GetMouseButton(2))
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            transform.RotateAround(targetPos, transform.up, mouseInputX * Time.deltaTime * 400f);
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 400f);
        }

        if (Input.GetKey(KeyCode.R))
        {
            CameraReset();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 5;
    }

    public void CameraReset()
    {
        transform.position = startPos;
        transform.rotation = startRote;
        centerObj.transform.position = startPosC;
    }
}
