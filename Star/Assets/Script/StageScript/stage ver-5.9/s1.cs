﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour
{

    public void s1011()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,2,1,1,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置) 上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
        int[] direction = { 6};

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 0, 0 };

        //評価
        int[] score = { 0, 0, 0 };

        //カメラの広さ(ステージの広さ)
        int camera = -5;

        //カメラ初期位置
        Vector3 center = new Vector3(1, -1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s1012()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置) 上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
        int[] direction = { 6 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 1, 0, 0 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -5;

        //カメラ初期位置
        Vector3 center = new Vector3(1, -1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s1013()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,5,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,2,1,5,1,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,3,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
        };

        //ギミックの向き(初期配置) 上0　左2　下4　右6　人工衛星　左斜め上1　左斜め下3
        int[] direction = { 3,6,3,3 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 1, 0, 0 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -7;

        //カメラ初期位置
        Vector3 center = new Vector3(2, -1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s1021()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
        int[] direction = { 6};

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 0, 1 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -11;

        //カメラ初期位置
        Vector3 center = new Vector3(4, -1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s1022()
    {
        //ステージマップ
        //　0=空白　1=空白マス　2=光源　3=クリア地点　4=隕石　5=人工衛星　6=増幅装置　7=分裂装置
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,2,1,1,7,1,1,5,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,4,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,5,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,4,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,3,1,1,4,1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
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
        int[] direction = { 6,4,1,3 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 0, 1 };

        //評価
        int[] score = { 0, 0, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -7;

        //カメラ初期位置
        Vector3 center = new Vector3(2, -2, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s1023()
    {
        //ステージマップ
        int[,] stage = new int[20, 20]
        {
            {1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
            {1,2,1,7,1,1,4,4,1,3,1,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
            {1,1,1,5,1,1,1,1,1,3,1,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置)
        int[] direction = { 6,4,1 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 0, 0, 2 };

        //評価
        int[] score = { 0, 0, 2
        };

        //カメラの広さ(ステージの広さ)
        int camera = -20;

        Vector3 center = new Vector3(1, 1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s103()
    {
        //ステージマップ
        int[,] stage = new int[20, 20]
        {
            {1,1,1,4,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {2,1,1,1,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,4,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置)
        int[] direction = { 6 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 4, 0, 0 };

        //評価
        int[] score = { 3, 2, 1 };

        //カメラの広さ(ステージの広さ)
        int camera = -20;

        Vector3 center = new Vector3(1, 1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s104()
    {
        //ステージマップ
        int[,] stage = new int[20, 20]
        {
            {2,1,1,4,1,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,4,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,4,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,4,1,4,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置)
        int[] direction = { 6 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 4, 0, 0 };

        //評価
        int[] score = { 4, 3, 2 };

        //カメラの広さ(ステージの広さ)
        int camera = -20;

        Vector3 center = new Vector3(1, 1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

    public void s105()
    {
        //ステージマップ
        int[,] stage = new int[20, 20]
        {
            {1,1,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {2,1,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {3,1,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
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
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        //ギミックの向き(初期配置)
        int[] direction = { 6 };

        //保持しているギミック{人工衛星,増幅装置,分裂装置}
        int[] obj = { 2, 0, 1 };

        //評価
        int[] score = { 0, 0, 3 };

        //カメラの広さ(ステージの広さ)
        int camera = -20;

        Vector3 center = new Vector3(1, 1, 0);

        StageDirector.StageSet(stage, direction, obj, score, camera, center);
    }

}
