using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    public LayerMask satellitemask;
    public LayerMask squaremask;
    //移動中のオブジェクト
    GameObject satellite = null;
    //移動中のオブジェクトの前の親
    GameObject satelliteParent = null;
    //Rayの長さ
    float raydistans = 70;
    GameDirector gameDirector;


    void Start() {
        gameDirector = GetComponent<GameDirector>();
    }

    void Update() {
        //Rayの作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //左クリックで移動
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(2)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                if (Moveflag(hit.collider.gameObject)) {
                    satellite = hit.collider.gameObject;
                    satellite.GetComponent<BoxCollider>().enabled = false;
                    gameDirector.ReLight();
                    gameDirector.lightObj.Add(satellite);
                }
            }
            //右クリックでオブジェクトの回転
        } else if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(2)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                Spin(hit.collider.gameObject);
                gameDirector.ReLight();
            }
        } else if (Input.GetMouseButtonUp(0) && satellite != null) {
            satellite.GetComponent<BoxCollider>().enabled = true;
            satellite = null;
            gameDirector.ReLight();
        }
        if (satellite != null) {
            if (Physics.Raycast(ray, out hit, raydistans, squaremask)) {
                ObjMove(hit.collider.gameObject);
            }
        }
    }

    bool Moveflag(GameObject obj) {
        switch (obj.tag) {
            case "Mirror":
                return obj.GetComponent<Mirror>().moveFlag;
            case "Power":
                return obj.GetComponent<Power>().moveFlag;
            case "Split":
                return obj.GetComponent<Split>().moveFlag;
        }
        return false;
    }

    void Spin(GameObject obj) {
        switch (obj.tag) {
            case "Mirror":
                obj.GetComponent<Mirror>().Spin();
                break;
            case "Power":
                obj.GetComponent<Power>().Spin();
                break;
            case "Split":
                obj.GetComponent<Split>().Spin();
                break;

        }

    }

    void ObjMove(GameObject obj) {
        bool flag = obj.GetComponent<Square>().SetObj(satellite);
        if (!flag) {
            satellite.SetActive(false);

        }
    }


}
