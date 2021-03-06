﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    public LayerMask satellitemask;
    public LayerMask squaremask;
    //移動中のオブジェクト
    GameObject satellite = null;
    //Rayの長さ
    float raydistans = 70;
    GameDirector gameDirector;
    //object移動(UI)
    [SerializeField] GameObject[] satelliteUI;
    RectTransform[] rectTransform;
    //表示されているマス目
    GameObject OnSquare = null;
    //マス目を表示させるためのメッシュ
    [SerializeField] Mesh _mesh;
    //音
    [SerializeField] AudioSource[] audiosource; //0　設置, 1　回転, 2　移動

    void Start() {
        gameDirector = GetComponent<GameDirector>();
        rectTransform = new RectTransform[satelliteUI.Length];
        for (int i = 0; i < satelliteUI.Length; i++) {
            rectTransform[i] = satelliteUI[i].GetComponent<RectTransform>();
        }
    }

    void Update() {
        //Rayの作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //左クリックで移動
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(2)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                if (Moveflag(hit.collider.gameObject)) MoveObject(hit.collider.gameObject);
            }
        }
        //右クリックでオブジェクトの回転
        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(2) && !Input.GetMouseButton(0)) {
            if (Physics.Raycast(ray, out hit, raydistans, satellitemask)) {
                if (Moveflag(hit.collider.gameObject)) {
                    Spin(hit.collider.gameObject);
                    audiosource[1].Play();
                    gameDirector.ReLight();
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && satellite != null) {
            gameDirector.lightObj.Add(satellite);
            satellite.GetComponent<BoxCollider>().enabled = true;
            UIMove(true);
            if (Physics.Raycast(ray, out hit, raydistans, squaremask)) {
                if (hit.collider.tag == "Square") {
                    bool flag = hit.collider.GetComponent<Square>().SetObj(satellite);
                    if (!flag) gameDirector.Setobj(satellite);
                    else audiosource[0].Play();
                } else {
                    gameDirector.Setobj(satellite);
                }
            } else {
                gameDirector.Setobj(satellite);
            }
            satellite = null;
            gameDirector.ReLight();
        }
        if (satellite != null) {
            if (Physics.Raycast(ray, out hit, raydistans, squaremask)) {
                if (hit.collider.tag == "Square") {
                    bool flag = hit.collider.GetComponent<Square>().SetObj(satellite);
                    UIMove(flag);
                } else {
                    UIMove(false);
                }
            } else {
                UIMove(false);
            }
        }
        //マウスカーソルがマス目に重なったら表示する
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray2, out hit2, raydistans, squaremask)) {
            GameObject obj = hit2.collider.gameObject;
            if (obj.tag == "Square" && obj != OnSquare) {
                if (!obj.GetComponent<Square>().MarkFlag) {
                    if (OnSquare != null && OnSquare.tag == "Square") OnSquare.GetComponent<MeshFilter>().mesh = null;
                    obj.GetComponent<MeshFilter>().mesh = _mesh;
                    OnSquare = obj;
                }
            }
        } else if (OnSquare != null && OnSquare.tag == "Square") {
            OnSquare.GetComponent<MeshFilter>().mesh = null;
            OnSquare = null;
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

    public void MoveObject(GameObject obj) {
        audiosource[2].Play();
        satellite = obj;
        satellite.GetComponent<BoxCollider>().enabled = false;
        gameDirector.ReLight();
        gameDirector.lightObj.Add(satellite);
        if (obj.tag == "Split") gameDirector.SplitTurnCange(satellite);
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
                gameDirector.SplitTurnCange(obj);
                break;

        }

    }

    void UIMove(bool flag) {
        if (flag) {
            foreach (GameObject obj in satelliteUI) {
                obj.SetActive(false);
            }
            satellite.SetActive(true);
        } else {
            satellite.SetActive(false);
            switch (satellite.tag) {
                case "Mirror":
                    satelliteUI[0].SetActive(true);
                    rectTransform[0].position = Input.mousePosition;
                    break;
                case "Power":
                    satelliteUI[1].SetActive(true);
                    rectTransform[1].position = Input.mousePosition;
                    break;
                case "Split":
                    satelliteUI[2].SetActive(true);
                    rectTransform[2].position = Input.mousePosition;
                    break;
            }
        }
    }
}
