﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2 : MonoBehaviour
{

    public void s201()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {2,1,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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

        //ギミックの向き(初期配置) 上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
        int[] direction = { 6,3};

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 1, 0 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -6;

        //カメラ初期位置
        Vector3 center = new Vector3(1.5f, -2.5f, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s202()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {2,1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {3,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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

        //ギミックの向き(初期配置) 上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
        int[] direction = { 6,1,3};

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 1, 0 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -6;

        //カメラ初期位置
        Vector3 center = new Vector3(1, -2.5f, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

}