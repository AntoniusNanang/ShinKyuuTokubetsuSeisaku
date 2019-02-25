using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : Satellite_Base {
    [SerializeField] protected int[] afterDir2 = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    int backupDir = -1;
    float backupPow = 0;


    public void RayCast(int dir, float pow) { //光の方向と強さを受け取る
        //入射方向
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;

        if (InLight == 0 && afterDir[x] >= 0) {
            int d = afterDir[x];
            //放射方向2
            int d2 = afterDir2[x];

            //照射威力
            float nextPow = Mathf.Min(pow * afterPow, 4);

            InLight++;

            if (d >= 0 && nextPow >= 1) {
                //光を飛ばす方向を決定する
                Vector3 nextDir = Dir[(d + nowforward) % 8];

                //Rayの作成
                Ray ray = new Ray(transform.position, nextDir);
                RaycastHit hit;


                //Rayがぶつかったオブジェクトまで線を描き、光を渡す
                if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                    drawLine(InLight, hit.collider.transform.position, pow, nextPow);
                    HitRay(hit.collider.gameObject, (d + nowforward) % 8, nextPow);

                } else {
                    drawLine(InLight, transform.position + nextDir * 20, pow, nextPow);
                }
            } 
            if (d2 >= 0 && nextPow >= 1) {
                //光を飛ばす方向を決定する
                Vector3 nextDir = Dir[(d2 + nowforward) % 8];

                //Rayの作成
                Ray ray = new Ray(transform.position, nextDir);
                RaycastHit hit;

                //Rayがぶつかったオブジェクトまで線を描き、光を渡す
                if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                    drawLine(InLight + 1, hit.collider.transform.position, pow, nextPow);
                    HitRay(hit.collider.gameObject, (d2 + nowforward) % 8, nextPow);

                } else {
                    drawLine(InLight + 1, transform.position + nextDir * 20, pow, nextPow);
                }

            }
            backupDir = x;
            backupPow = pow;
        } else if (InLight == 1 && backupDir != x && afterDir[x] >= 0) {

            //照射方向
            int d = (x == 4) ? backupDir : 0;
            d = (backupDir == 4) ? x : d;

            //照射威力
            float nextPow = (backupPow + pow == 2) ? 2 : 4;


            if (d >= 0 && nextPow >= 1 && MaxInLight > InLight) {

                Lightoff();
                //光を飛ばす方向を決定する
                Vector3 nextDir = Dir[(d + nowforward) % 8];

                //Rayの作成
                Ray ray = new Ray(transform.position, nextDir);
                RaycastHit hit;

                InLight = 2;

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

    new public void Lightoff() {
        for (int i = 0; i < line.Length; i++) {
            line[i].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            line[i].GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
        InLight = 0;
        backupDir = -1;
        backupPow = 0;
    }
}
