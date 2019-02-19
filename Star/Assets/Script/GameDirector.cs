using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    public GameObject Sun;
    public LayerMask layermask;
    //光源のスタート方向
    int StartDir = 6;
    //光を飛ばしているオブジェクト
    public List<GameObject> lightObj = new List<GameObject>();
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(2)) {
            ReLight();
        } else if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(2)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                hit.collider.GetComponent<Satellite>().Spin();
                ReLight();
            }
        }
    }

    void ReLight() {
        for(int i = 0; i < lightObj.Count; i++) {
            lightObj[i].GetComponent<Satellite>().Lightoff();
        }
        lightObj.Clear();
        Sun.GetComponent<Satellite>().RayCast(StartDir, 4);
    }
}
