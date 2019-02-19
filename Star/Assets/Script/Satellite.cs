using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {
    [SerializeField] GameObject GameRoot;
    public LayerMask layermask;
    [SerializeField] GameObject line;
    //光の入射方向と照射方向
    [SerializeField] int[] afterDir = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    Vector3[] Dir = new Vector3[8] {
        new Vector3(0, 1, 0), new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0), new Vector3(-1, -1, 0),
        new Vector3(0, -1, 0), new Vector3(1, -1, 0),
        new Vector3(1, 0, 0), new Vector3(1, 1, 0)
    };
    //光の強さの変更
    [SerializeField]int afterPow = 1;
    //一回で回転する量
    int rotate = 2;
    //光が入れる数
    [SerializeField] int MaxInLight = 1;
    //現在の回転角度
    [SerializeField] int nowforward = 0;
    //光の入ってきている数
    int InLight = 0;


    void Start() {
        Lightoff();
    }

    public void RayCast(int dir, int pow) { //光の方向と強さを受け取る
        //照射方向
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;
        int d = afterDir[x];
        //照射威力
        int nextPow = Mathf.Min(pow * afterPow, 4);

        if (d >= 0 && nextPow > 1 && MaxInLight > InLight) {
            //光を飛ばす方向を決定する
            Vector3 nextDir = Dir[(d + nowforward) % 8];
            
            //Rayの作成
            Ray ray = new Ray(transform.position, nextDir);
            RaycastHit hit;

            InLight++;
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                line.GetComponent<LineRenderer>().SetPosition(1, hit.point);
                hit.collider.GetComponent<Satellite>().RayCast((d + nowforward) % 8, nextPow);
            } else {
                line.GetComponent<LineRenderer>().SetPosition(1, transform.position + nextDir * 5);
            }
            GameRoot.GetComponent<GameDirector>().lightObj.Add(this.gameObject);
            Debug.Log(gameObject.name + InLight);
        }
    }

    //オブジェクトの回転
    public void Spin() {
        transform.Rotate(0, 0, 45 * rotate);
        nowforward = (nowforward + rotate) % 8;
    }

    //光線のリセット
    public void Lightoff() {
        line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, transform.position);
        InLight = 0;
    }
}
