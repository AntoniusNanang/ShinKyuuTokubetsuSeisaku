using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

    public void SetObj(GameObject obj) {
        if (transform.childCount == 0) {
            obj.transform.parent = transform;
            obj.transform.position = transform.position;
        }
    }
}
