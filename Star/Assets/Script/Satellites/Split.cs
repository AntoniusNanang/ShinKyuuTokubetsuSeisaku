using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : Satellite_Base {
    [SerializeField] protected int[] afterDir2 = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    public int backupDir = -1;
    public float backupPow = 0;


    public void RayCast(int dir, float pow) { //光の方向と強さを受け取る(world)
        //入射方向x(local)
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;

        if (pow >= 1 && afterDir[x] >= 0) {
            if (InLight == 0) {
                //照射方向d, d2(local)
                int d = afterDir[x];
                int d2 = afterDir2[x];
                //照射威力
                float nextPow = Mathf.Min(pow * afterPow, 4);
                if (d >= 0) {
                    InLight++;
                    //照射威力が足りるとき
                    if (nextPow >= 1) {
                        //照射方向1(world)
                        Vector3 nextDir1 = Dir[(d + nowforward) % 8];
                        //Rayの作成
                        Ray ray1 = new Ray(transform.position, nextDir1);
                        RaycastHit hit1;
                        //Rayがぶつかったオブジェクトまで線を描き、光を渡す
                        if (Physics.Raycast(ray1, out hit1, 20.0f, layermask)) {
                            drawLine(d, hit1.collider.transform.position, pow, nextPow);
                            HitRay(hit1.collider.gameObject, (d + nowforward) % 8, nextPow);
                        } else {
                            drawLine(d, transform.position + nextDir1 * 20, pow, nextPow);
                        }
                        //照射方向2(world)
                        Vector3 nextDir2 = Dir[(d2 + nowforward) % 8];
                        //Rayの作成
                        Ray ray2 = new Ray(transform.position, nextDir2);
                        RaycastHit hit2;
                        //Rayがぶつかったオブジェクトまで線を描き、光を渡す
                        if (Physics.Raycast(ray2, out hit2, 20.0f, layermask)) {
                            drawLine(d2, hit2.collider.transform.position, pow, nextPow);
                            HitRay(hit2.collider.gameObject, (d2 + nowforward) % 8, nextPow);
                        } else {
                            drawLine(d2, transform.position + nextDir2 * 20, pow, nextPow);
                        }
                    //照射威力が足りないとき
                    } else if (nextPow == 0.5f) GameRoot.GetComponent<GameDirector>().lightObj.Add(this.gameObject);
                    backupDir = x;
                    backupPow = pow;
                }
            //光がすでに1本入ってきているとき
            } else if (InLight == 1 && backupDir != x) {
                //照射方向(local)
                int d = -1;
                if (backupDir != 2 && x != 2) d = 6;
                else if (backupDir != 4 && x != 4) d = 4;
                else if (backupDir != 6 && x != 6) d = 2;
                //照射威力
                float nextPow = 0;
                if (backupPow == 1 && pow == 1) nextPow = 2;
                else if (backupPow >= 1 && pow >= 1) nextPow = 4;
                //光線をリセット
                Lightoff();
                InLight = 2;
                //照射方向(world)
                Vector3 nextDir = Dir[(d + nowforward) % 8];
                //Rayの作成
                Ray ray = new Ray(transform.position, nextDir);
                RaycastHit hit;
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
