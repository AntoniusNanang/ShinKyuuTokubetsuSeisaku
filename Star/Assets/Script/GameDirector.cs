using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
    public GameObject Sun;
    //光源のスタート方向
    public int StartDir = 6;
    //光を飛ばしているオブジェクト
    public List<GameObject> lightObj = new List<GameObject>();
    //手持ち
    [SerializeField] List<GameObject> MyMirror = new List<GameObject>();
    [SerializeField] List<GameObject> MyPower = new List<GameObject>();
    [SerializeField] List<GameObject> MySplit = new List<GameObject>();
    //objectの保持数Text
    [SerializeField] Text[] haveLabel;

    ObjectController objCon;

    void Start() {
        Invoke("ReLight", 2);
        objCon = GetComponent<ObjectController>();
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
        }

    }


    public void ReLight() {
        for (int i = 0; i < lightObj.Count; i++) {
            Lightoff(lightObj[i]);
        }
        lightObj.Clear();
        Sun.GetComponent<Sun>().RayCast(StartDir, 4);
    }

    //手持ちからobjectを出す
    public void Getobj(int objNum) {
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

    //手持ちにobjectを戻す
    public void Setobj(GameObject obj) {
        switch (obj.tag) {
            case "Mirror":
                MyMirror.Add(obj);
                obj.SetActive(false);
                haveLabel[0].text = "×" + MyMirror.Count.ToString("D2");
                break;
            case "Power":
                MyPower.Add(obj);
                obj.SetActive(false);
                haveLabel[1].text = "×" + MyPower.Count.ToString("D2");
                break;
            case "Split":
                MySplit.Add(obj);
                obj.SetActive(false);
                haveLabel[2].text = "×" + MySplit.Count.ToString("D2");
                break;
        }

    }
}
