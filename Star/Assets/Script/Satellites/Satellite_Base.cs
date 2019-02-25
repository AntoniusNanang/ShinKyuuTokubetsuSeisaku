using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite_Base : MonoBehaviour {
    GameObject GameRoot;
    public LayerMask layermask;
    [SerializeField] protected GameObject[] line;
    //光の入射方向と照射方向
    [SerializeField] protected int[] afterDir = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    protected Vector3[] Dir = new Vector3[8] {
        new Vector3(0, 1, 0), new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0), new Vector3(-1, -1, 0),
        new Vector3(0, -1, 0), new Vector3(1, -1, 0),
        new Vector3(1, 0, 0), new Vector3(1, 1, 0)
    };
    //光の強さの色
    Color[] color = new Color[5] {
        Color.black, Color.white, Color.yellow, Color.black, Color.red
    };
    //光の強さの変更
    [SerializeField] protected float afterPow = 1;
    //一回で回転する量
    int rotate = 2;
    //光が入れる数
    [SerializeField] protected int MaxInLight = 1;
    //現在の回転角度
    public int nowforward = 0;
    //光の入ってきている数
    [SerializeField] protected int InLight = 0;

    public bool moveFlag = true;


    void Start() {
        Lightoff();
        GameRoot = GameObject.Find("GameRoot");
    }

    //オブジェクトの回転
    public void Spin() {
        transform.Rotate(0, 0, 45 * rotate);
        nowforward = (nowforward + rotate) % 8;
    }
    
    //Rayがあたったとき
    protected void HitRay(GameObject obj, int dir, float pow) {
        switch (obj.tag) {
            case "Sun":
                break;
            case "Mirror":
                obj.GetComponent<Mirror>().RayCast(dir, pow);
                break;
            case "Power":
                obj.GetComponent<Power>().RayCast(dir, pow);
                break;
            case "Split":
                obj.GetComponent<Split>().RayCast(dir, pow);
                break;
            case "Meteo":
                obj.GetComponent<Meteo>().RayCast(dir, pow);
                break;
            case "Star":
                break;
        }
    }

    //光線のリセット
    public void Lightoff() {
        for(int i = 0; i < line.Length; i++) {
            line[i].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            line[i].GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
        InLight = 0;
    }

    //光線を飛ばす
    protected void drawLine(int count, Vector3 pos, float startpow, float endpow) {
        line[count - 1].GetComponent<LineRenderer>().sortingOrder = (int)endpow;
        line[count - 1].GetComponent<LineRenderer>().SetPosition(1, pos);
        line[count - 1].GetComponent<LineRenderer>().startColor = color[(int)endpow];
        line[count - 1].GetComponent<LineRenderer>().endColor = color[(int)endpow];
        GameRoot.GetComponent<GameDirector>().lightObj.Add(this.gameObject);
    }
}
