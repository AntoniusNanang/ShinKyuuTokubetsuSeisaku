using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
    public GameObject Sun;
    //光源のスタート方向
    public int StartDir = 6;
    //光を飛ばしているオブジェクト
    public List<GameObject> lightObj = new List<GameObject>();

    void Start() {
        Invoke("ReLight", 2);
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
}
