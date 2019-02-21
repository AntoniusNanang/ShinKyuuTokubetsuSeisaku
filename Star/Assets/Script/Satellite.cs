using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {
    [SerializeField] GameObject GameRoot;
    public LayerMask layermask;
    [SerializeField] GameObject[] line;
    //光の入射方向と照射方向
    [SerializeField] int[] afterDir = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    [SerializeField] int[] afterDir2 = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };
    Vector3[] Dir = new Vector3[8] {
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
    [SerializeField] float afterPow = 1;
    //一回で回転する量
    int rotate = 2;
    //光が入れる数
    [SerializeField] int MaxInLight = 1;
    //現在の回転角度
    public int nowforward = 0;
    //光の入ってきている数
    [SerializeField] int InLight = 0;
    public bool moveFlag = true;


    void Start() {
        Lightoff();
        GameRoot = GameObject.Find("GameRoot");
    }

    public void RayCast(int dir, float pow) { //光の方向と強さを受け取る
        //照射方向
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;
        int d = afterDir[x];
        //2本目の照射方向
        int x2 = dir - nowforward;
        x2 = (x2 >= 0) ? x2 : 8 + x2;
        int d2 = afterDir2[x2];

        //照射威力
        float nextPow = Mathf.Min(pow * afterPow, 4);

        if (d >= 0 && nextPow >= 1 && MaxInLight > InLight) {
            //光を飛ばす方向を決定する
            Vector3 nextDir = Dir[(d + nowforward) % 8];
            
            //Rayの作成
            Ray ray = new Ray(transform.position, nextDir);
            RaycastHit hit;

            InLight++;
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                drawLine(InLight, hit.collider.transform.position, pow, nextPow);
                hit.collider.GetComponent<Satellite>().RayCast((d + nowforward) % 8, nextPow);
            } else {
                drawLine(InLight, transform.position + nextDir * 20, pow, nextPow);
            }
            GameRoot.GetComponent<GameDirector>().lightObj.Add(this.gameObject);
        }
        if (d2 >= 0 && nextPow >= 1 && MaxInLight >= InLight) {
            //光を飛ばす方向を決定する
            Vector3 nextDir = Dir[(d2 + nowforward) % 8];

            //Rayの作成
            Ray ray = new Ray(transform.position, nextDir);
            RaycastHit hit;
            
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                drawLine(InLight + 1, hit.collider.transform.position, pow, nextPow);
                hit.collider.GetComponent<Satellite>().RayCast((d2 + nowforward) % 8, nextPow);
            } else {
                drawLine(InLight + 1, transform.position + nextDir * 20, pow, nextPow);
            }
            GameRoot.GetComponent<GameDirector>().lightObj.Add(this.gameObject);

        }

    }

    //オブジェクトの回転
    public void Spin() {
        transform.Rotate(0, 0, 45 * rotate);
        nowforward = (nowforward + rotate) % 8;
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
    void drawLine(int count, Vector3 pos, float startpow, float endpow) {
        line[count - 1].GetComponent<LineRenderer>().SetPosition(1, pos);
        line[count - 1].GetComponent<LineRenderer>().startColor = color[(int)endpow];
        line[count - 1].GetComponent<LineRenderer>().endColor = color[(int)endpow];
    }
}
