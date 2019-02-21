using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    public GameObject Sun;
    public LayerMask satellitemask;
    public LayerMask squaremask;
    //光源のスタート方向
    int StartDir = 6;
    //光を飛ばしているオブジェクト
    public List<GameObject> lightObj = new List<GameObject>();
    //移動中のオブジェクト
    GameObject satellite = null;
    //Rayの長さ
    float raydistans = 40;

    void Start() {
        ReLight();
    }
	
	void Update () {
        //Rayの作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //左クリックで移動
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(2)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                if (hit.collider.GetComponent<Satellite>().moveFlag == true) {
                    satellite = hit.collider.gameObject;
                    satellite.GetComponent<BoxCollider>().enabled = false;
                    ReLight();
                }
            }
        //右クリックでオブジェクトの回転
        } else if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(2)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                hit.collider.GetComponent<Satellite>().Spin();
                ReLight();
            }
        } else if (Input.GetMouseButtonUp(0) && satellite != null) {
            satellite.GetComponent<BoxCollider>().enabled = true;
            satellite.GetComponent<Satellite>().Lightoff();
            satellite = null;
            ReLight();
        }
        if (satellite != null) {
            if (Physics.Raycast(ray, out hit, raydistans, squaremask)) {
                hit.collider.GetComponent<Square>().SetObj(satellite);
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
