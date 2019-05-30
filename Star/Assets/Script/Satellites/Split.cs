using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : Satellite_Base {
    [SerializeField] protected int[] afterDir2 = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    float[] havePow = new float[8] { -1, -1, 0, -1, 0, -1, 0, -1 };  //受け取った光の強さを保存しておく
    bool lightflag = false; //true = 光を飛ばしている
    
    public int backupDir = -1;
    public float backupPow = 0;


    public void RayCast(int dir, float pow) { //光の方向と強さを受け取る(world)
        //入射方向x(local)
        int x = dir - nowforward;
        x = (x >= 0) ? x : 8 + x;

        //光を保存する
        havePow[x] = (havePow[x] == 0) ? pow : havePow[x];
    }

    public bool Lighton() {
        InLight = 0;
        //光をすでに飛ばしていたら終了
        if (lightflag) return false;

        //光の入ってきた数と方向と強さをまとめる
        int[] lightvec = new int[3] { -1, -1 , -1}; //2, 4, 6
        float[] lightpow = new float[3] { -1, -1 , -1}; //1, 2, 4
        for (int i = 0; i < 8; i++) {
            if (havePow[i] >= 1) {
                lightvec[InLight] = i;          //方向
                lightpow[InLight] = havePow[i]; //強さ
                InLight++;                      //数
            }
        }

        //光が全方向から入ってきている場合、もしくはどこからも来ていなかったら終了
        if (InLight > 2 || InLight < 1) return false;
        

        //光を飛ばす方向と強さを決定する
        int[] nextlocalLightvec = new int[2];
        Vector3[] nextLightvec = new Vector3[2]; //2, 4, 6
        float nextPow = -1;
        if (InLight == 1) { //光が1本入ってきているとき
            //強さ
            nextPow = Mathf.Min(lightpow[0] * afterPow, 4);
            //光の強さが弱いときは終了
            if (nextPow < 1) return false;
            //方向
            nextlocalLightvec[0] = afterDir[lightvec[0]];
            nextlocalLightvec[1] = afterDir2[lightvec[0]];
            nextLightvec[0] =  Dir[(nextlocalLightvec[0] + nowforward) % 8];
            nextLightvec[1] =  Dir[(nextlocalLightvec[1] + nowforward) % 8];
        } else if (InLight == 2) {  //光が2本入ってきているとき
            //強さ
            nextPow = (lightpow[0] == 1 && lightpow[1] == 1) ? 2 : 4;
            //方向
            nextlocalLightvec[0] = -1;
            if (lightvec[0] != 2 && lightvec[1] != 2) nextlocalLightvec[0] = 6;
            else if (lightvec[0] != 4 && lightvec[1] != 4) nextlocalLightvec[0] = 0;
            else if (lightvec[0] != 6 && lightvec[1] != 6) nextlocalLightvec[0] = 2;
            nextLightvec[0] = Dir[(nextlocalLightvec[0] + nowforward) % 8];
        }


        //光を飛ばす
        if (InLight == 1) {
            //Rayの作成
            Ray ray = new Ray(transform.position, nextLightvec[0]);
            RaycastHit hit;
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                drawLine(nextlocalLightvec[0], hit.collider.transform.position, nextPow, nextPow);
                HitRay(hit.collider.gameObject, (nextlocalLightvec[0] + nowforward) % 8, nextPow);
            } else {
                drawLine(nextlocalLightvec[0], transform.position + nextLightvec[0] * 20, nextPow, nextPow);
            }
            //Rayの作成
            Ray ray2 = new Ray(transform.position, nextLightvec[1]);
            RaycastHit hit2;
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray2, out hit2, 20.0f, layermask)) {
                drawLine(nextlocalLightvec[1], hit2.collider.transform.position, nextPow, nextPow);
                HitRay(hit2.collider.gameObject, (nextlocalLightvec[1] + nowforward) % 8, nextPow);
            } else {
                drawLine(nextlocalLightvec[1], transform.position + nextLightvec[1] * 20, nextPow, nextPow);
            }

        } else if (InLight == 2) {
            //Rayの作成
            Ray ray = new Ray(transform.position, nextLightvec[0]);
            RaycastHit hit;
            //Rayがぶつかったオブジェクトまで線を描き、光を渡す
            if (Physics.Raycast(ray, out hit, 20.0f, layermask)) {
                drawLine(nextlocalLightvec[0], hit.collider.transform.position, nextPow, nextPow);
                HitRay(hit.collider.gameObject, (nextlocalLightvec[0] + nowforward) % 8, nextPow);
            } else {
                drawLine(nextlocalLightvec[0], transform.position + nextLightvec[0] * 20, nextPow, nextPow);
            }
        }
        lightflag = true;
        return true;
    }

    new public void Lightoff() {
        for (int i = 0; i < line.Length; i++) {
            line[i].GetComponent<LineRenderer>().SetPosition(0, transform.position);
            line[i].GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
        havePow = new float[8] { -1, -1, 0, -1, 0, -1, 0, -1 };
        lightflag = false;
        InLight = 0;
        backupDir = -1;
        backupPow = 0;
    }
}
