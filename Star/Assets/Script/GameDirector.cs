using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
    public List<GameObject> Sun;
    public List<GameObject> Star;
    //光源のスタート方向
    public List<int> StartDir;
    //光を飛ばしているオブジェクト
    public List<GameObject> lightObj = new List<GameObject>();
    //手持ち
    [SerializeField] List<GameObject> MyMirror = new List<GameObject>();
    [SerializeField] List<GameObject> MyPower = new List<GameObject>();
    [SerializeField] List<GameObject> MySplit = new List<GameObject>();
    //objectの保持数Text
    [SerializeField] Text[] haveLabel;
    //触ったオブジェクトを最後に触った順にしまうリスト
    public List<GameObject> moveObj;
    public List<GameObject> moveObj2;
    public List<int> moveNum;

    ObjectController objCon;

    void Start() {
        Invoke("ReLight", 2);
        objCon = GetComponent<ObjectController>();
        moveObj.Clear();
        moveObj2.Clear();
    }


    void Lightoff(GameObject obj) {
        switch (obj.tag) {
            case "Sun":
                obj.GetComponent<Sun>().Lightoff();
                break;
            case "Mirror":
                obj.GetComponent<Mirror>().Lightoff();
                break;
            case "Power":
                obj.GetComponent<Power>().Lightoff();
                break;
            case "Split":
                obj.GetComponent<Split>().Lightoff();
                break;
            case "Meteo":
                obj.GetComponent<Meteo>().Lightoff();
                break;
            case "Star":
                obj.GetComponent<Star>().Lightoff();
                break;
        }

    }


    public void ReLight() {
        for (int i = 0; i < Star.Count; i++) Star[i].GetComponent<Star>().Lightoff();
        for (int i = 0; i < lightObj.Count; i++) {
            Lightoff(lightObj[i]);
        }
        lightObj.Clear();
        for (int i = 0; i < Sun.Count; i++) Sun[i].GetComponent<Sun>().RayCast(StartDir[i], 4);

    }

    //手持ちからobjectを出す
    public void Getobj(int objNum) {
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {
            switch (objNum) {
                case 0:
                    if (MyMirror.Count > 0) {
                        objCon.MoveObject(MyMirror[0]);
                        MyMirror.RemoveAt(0);
                    }
                    haveLabel[objNum].text = "×" + MyMirror.Count.ToString("D2");
                    break;
                case 1:
                    if (MyPower.Count > 0) {
                        objCon.MoveObject(MyPower[0]);
                        MyPower.RemoveAt(0);
                    }
                    haveLabel[objNum].text = "×" + MyPower.Count.ToString("D2");
                    break;
                case 2:
                    if (MySplit.Count > 0) {
                        objCon.MoveObject(MySplit[0]);
                        MySplit.RemoveAt(0);
                    }
                    haveLabel[objNum].text = "×" + MySplit.Count.ToString("D2");
                    break;
            }
        }
    }

    //手持ちにobjectを戻す
    public void Setobj(GameObject obj) {
        switch (obj.tag) {
            case "Mirror":
                MyMirror.Add(obj);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                haveLabel[0].text = "×" + MyMirror.Count.ToString("D2");
                break;
            case "Power":
                MyPower.Add(obj);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                haveLabel[1].text = "×" + MyPower.Count.ToString("D2");
                break;
            case "Split":
                MySplit.Add(obj);
                obj.transform.parent = gameObject.transform;
                obj.SetActive(false);
                haveLabel[2].text = "×" + MySplit.Count.ToString("D2");
                break;
        }

    }
    //操作を保存する
    public void SaveMove(GameObject obj1, GameObject obj2, int num) {
        moveObj.Insert(0, obj1);
        moveObj2.Insert(0, obj2);
        moveNum.Insert(0, num);
    }

    //操作を一つ戻す
    public void Back() {
        if (moveObj.Count > 0) {
            GameObject obj = moveObj[0];
            if (moveObj2[0].tag == "GameRoot") {
                ChakeObj(obj);
                Setobj(obj);
            } else {
                if (moveNum[0] == 0) {
                    if (obj.transform.parent.tag == "GameRoot") {
                        ChakeObj(obj);
                    }
                    moveObj2[0].GetComponent<Square>().SetObj(obj);
                    lightObj.Add(obj);
                } else {
                    switch (obj.tag) {
                        case "Mirror":
                            obj.GetComponent<Mirror>().Spin(1);
                            break;
                        case "Power":
                            obj.GetComponent<Power>().Spin(1);
                            break;
                        case "Split":
                            obj.GetComponent<Split>().Spin(1);
                            break;
                    }
                }
            }
            moveObj.RemoveAt(0);
            moveObj2.RemoveAt(0);
            moveNum.RemoveAt(0);
            ReLight();
        }
    }

    //同じものを持っていたらリストから消してくれる
    void ChakeObj(GameObject obj) {
        switch (obj.tag) {
            case "Mirror":
                for (int i = 0; i < MyMirror.Count; i++) {
                    if (MyMirror[i] == obj) {
                        MyMirror.RemoveAt(i);
                        break;
                    }
                }
                break;
            case "Power":
                for (int i = 0; i < MyPower.Count; i++) {
                    if (MyPower[i] == obj) {
                        MyPower.RemoveAt(i);
                        break;
                    }
                }
                break;
            case "Split":
                for (int i = 0; i < MySplit.Count; i++) {
                    if (MySplit[i] == obj) {
                        MySplit.RemoveAt(i);
                        break;
                    }
                }
                break;
        }
    }


    //クリア判定
    public void StarShine(){
        bool clearFlag = true;
        for (int i = 0; i < Star.Count; i++) {
            clearFlag = (clearFlag) ? Star[i].GetComponent<Star>().ShineFlag : false;
        }
        
        if (clearFlag) {
            int count = MyMirror.Count + MyPower.Count + MySplit.Count;
            int Score = GetComponent<StageDirector>().ScoreChake(count);
            Debug.Log("Crear!! : " + Score);
        }
    }
}
