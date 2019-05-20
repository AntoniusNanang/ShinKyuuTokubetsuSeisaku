using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDirector : MonoBehaviour {
    [SerializeField] GameDirector gameDirector;
    //ステージのマップ
    static int[,] stageMap = new int[20, 20];
    //ステージ上のギミックの初期方向
    static int[] startdirection;
    //保持しているギミックの数
    static int[] haveObj;
    //評価
    static int[] score;
    //カメラの広さ
    static int camera_;
    //カメラの初期位置
    static Vector3 center_;
    //マス目の親の親
    [SerializeField] GameObject squaresParent;
    //Prefab
    [SerializeField] GameObject[] Prefabs;
    //初期位置
    Vector3 startPos = new Vector3(0, 0, -5);
    //動かないオブジェクトのマスのマテリアル
    [SerializeField] Material squaresMaterial;

    //************************************************************************************************************
    //1
    //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
    int[,] a01 = new int[20, 20]
        {
            {1,1,1,1,1,3,4,1,1,1,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,2,1,1,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,7,1,5,0,0,0,0,0,0,0,0,0,0 },
            {1,4,1,4,1,1,1,1,4,1,0,0,0,0,0,0,0,0,0,0 },
            {4,1,4,1,1,1,1,4,4,1,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,1,4,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
            {1,4,1,1,4,1,4,1,4,1,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,4,1,1,1,4,1,1,0,0,0,0,0,0,0,0,0,0 },
            {4,1,4,1,1,4,1,1,1,4,0,0,0,0,0,0,0,0,0,0 },
            {3,4,1,4,1,1,1,3,1,4,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

    // プレイヤーの各保持数{人工衛星,増幅装置,分裂装置}
    int[] a02 = new int[] { 8, 0, 8 };
    // Y=20～33 X=20～30
    //　光源、増幅装置、分裂装置　上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
    int[] a03 = new int[] { 4, 0, 1 };
    //評価
    int[] a04 = new int[3] { 12, 10, 8 };

    Vector3 a05 = new Vector3(1, -1, 0);


    void Start() {
        StageSet(a01, a03, a02, a04, -10, a05);
        CenterMove.centerPos = center_;
        CameraController.camera_z = camera_;
        CreateStage();
    }

    //ステージ情報を設定
    static public void StageSet(int[,] map, int[] dir, int[] objects, int[] _score, int camera, Vector3 center) {
        stageMap = map;
        startdirection = dir;
        haveObj = objects;
        score = _score;
        camera_ = camera;
        center_ = center;
    }

    //ステージを生成
    void CreateStage() {
        int countObj = 0;
        //マス目の親を取得
        GameObject[] squares = new GameObject[20];
        for (int i = 0; i < 20; i++) {
            squares[i] = squaresParent.transform.GetChild(i).gameObject;
        }


        for (int i = 0; i < 20; i++) {
            for (int j = 0; j < 20; j++) {
                GameObject square = squares[i].transform.GetChild(j).gameObject;
                GameObject obj = null;

                switch (stageMap[i, j]) {
                    case 0:
                        square.SetActive(false);
                        break;
                    case 2:
                        obj = Instantiate(Prefabs[0]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        gameDirector.StartDir.Add(startdirection[countObj]);
                        gameDirector.Sun.Add(obj);
                        obj.GetComponent<Sun>().Lightoff();
                        countObj++;
                        break;
                    case 3:
                        obj = Instantiate(Prefabs[1]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        gameDirector.Star.Add(obj);
                        break;
                    case 4:
                        obj = Instantiate(Prefabs[2]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        obj.GetComponent<Meteo>().Lightoff();
                        break;
                    case 5:
                        obj = Instantiate(Prefabs[3]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        obj.GetComponent<Mirror>().nowforward = startdirection[countObj];
                        obj.transform.Rotate(0, 0, 45 * startdirection[countObj]);
                        obj.GetComponent<Mirror>().Lightoff();
                        obj.GetComponent<Mirror>().moveFlag = false;
                        countObj++;
                        break;
                    case 6:
                        obj = Instantiate(Prefabs[4]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        obj.GetComponent<Power>().nowforward = startdirection[countObj];
                        obj.transform.Rotate(0, 0, 45 * startdirection[countObj]);
                        obj.GetComponent<Power>().Lightoff();
                        obj.GetComponent<Power>().moveFlag = false;
                        countObj++;
                        break;
                    case 7:
                        obj = Instantiate(Prefabs[5]);
                        square.GetComponent<Square>().SetObj(obj);
                        square.GetComponent<Renderer>().material = squaresMaterial;
                        obj.GetComponent<Split>().nowforward = startdirection[countObj];
                        obj.transform.Rotate(0, 0, 45 * startdirection[countObj]);
                        obj.GetComponent<Split>().Lightoff();
                        obj.GetComponent<Split>().moveFlag = false;
                        gameDirector.SplitTurnCange(obj);
                        countObj++;
                        break;
                    case 8:


                        break;
                }
                square.GetComponent<MeshFilter>().mesh = null;
            }
        }
        //所持アイテムを生成
        GameObject myobj = null;
        for (int i = 0; i < haveObj[0]; i++) {
            myobj = Instantiate(Prefabs[3]);
            myobj.GetComponent<Mirror>().nowforward = 1;
            myobj.transform.Rotate(0, 0, 45);
            gameDirector.Setobj(myobj);
        }
        for (int i = 0; i < haveObj[1]; i++) {
            myobj = Instantiate(Prefabs[4]);
            gameDirector.Setobj(myobj);
        }
        for (int i = 0; i < haveObj[2]; i++) {
            myobj = Instantiate(Prefabs[5]);
            gameDirector.Setobj(myobj);
            gameDirector.SplitTurnCange(myobj);
        }

    }

    //手持ちのオブジェクトの数を受け取って、評価を返す
    public int ScoreChake(int con) {
        int count = 0;
        for (int i = 0; i < haveObj.Length; i++) {
            count += haveObj[i];
        }
        count -= con;
        for (int i = 2; i >= 0; i--) {
            if (count <= score[i]) return i + 1;
        }
        return 0;
    }
}
