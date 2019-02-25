using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Satellite_Base {

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
                drawLine(InLight, hit.collider.transform.position, pow, nextPow);
                HitRay(hit.collider.gameObject, (d + nowforward) % 8, nextPow);

            } else {
                drawLine(InLight, transform.position + nextDir * 20, pow, nextPow);
            }
        }
    }

}
