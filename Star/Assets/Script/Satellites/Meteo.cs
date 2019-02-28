using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : Satellite_Base {
    //[SerializeField] GameObject[] meteoChildren;
    //float rndx = 0.4f;
    //float rndy = 0.4f;
    //float rndz = 0.4f;

    //void Start() {
    //    for(int i = 0; i < meteoChildren.Length; i++) {
    //        //Vector3 pos = new Vector3(Random.Range(-rndx, rndx), Random.Range(-rndy, rndy), Random.Range(-rndz, rndz));
    //        Vector3 scale = new Vector3(Random.Range(0, rndx), Random.Range(0, rndy), Random.Range(0, rndz));
    //        meteoChildren[i].transform.localScale += scale;
    //    }
    //}




    public void RayCast(int dir, float pow) { //光の方向と強さを受け取る
        //照射方向
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;
        int d = afterDir[x];

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
                drawLine(d, hit.collider.transform.position, pow, nextPow);
                HitRay(hit.collider.gameObject, (d + nowforward) % 8, nextPow);

            } else {
                drawLine(d, transform.position + nextDir * 20, pow, nextPow);
            }
        }
    }

}
