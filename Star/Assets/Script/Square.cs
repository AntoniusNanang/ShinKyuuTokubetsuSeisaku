using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public bool SetFlag = true;
    public bool MarkFlag = false;

    public bool SetObj(GameObject obj) {
        if (SetFlag) {
            if (transform.childCount == 0) {
                obj.SetActive(true);
                Vector3 childPos = transform.position;
                childPos.z = obj.transform.position.z;
                obj.transform.parent = transform;
                obj.transform.position = childPos;
                return true;
            } else if (transform.GetChild(0).gameObject == obj) {
                return true;
            }
        }
        return false;
    }
}
