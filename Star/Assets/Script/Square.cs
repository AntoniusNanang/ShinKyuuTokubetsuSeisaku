using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

    public bool SetObj(GameObject obj) {
        if (transform.childCount == 0) {
            obj.SetActive(true);
            obj.transform.parent = transform;
            obj.transform.position = transform.position;
            return true;
        } else if (transform.GetChild(0).gameObject == obj) {
            return true;
        }
        return false;
    }
}
