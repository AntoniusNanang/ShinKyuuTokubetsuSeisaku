using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISpin2 : MonoBehaviour {

   

    //回転速度
    private float speed = 10f;
    //アイテム格納
    public Image[] item;
    //半径
    private float[] r = new float [3];

    private List<RectTransform> transforms = new List<RectTransform>();
    private List<float> startRads = new List<float>();

    //親オブジェのtransを格納
    public Transform myTrans;

    RectTransform[] str_t=new RectTransform[2];
    float[] str_r = new float[2];

    bool onClick = false;
    float time;
    float rad;
    float nowRad;
    int cnt;
    int reset = 0;


    // Use this for initialization
    void Start () {

        
        int itemNum = item.Length;

        for (int i = 0; i < itemNum; i++)
        {

            item[i].transform.SetParent(myTrans, false);

            //半径を取得
            r[i] = item[i].rectTransform.localPosition.y;

            RectTransform trans ;
            trans = item[i].GetComponent<RectTransform>();

            //角度
            float angel = i * (-180 / itemNum) + 90;
            //ラジアン
            rad = angel * Mathf.Deg2Rad;
            Debug.Log("rad = " + rad);
            //座標変換
            float x = Mathf.Cos(rad) * r[i];
            float y = Mathf.Sin(rad) * r[i];

            //初期位置
            trans.anchoredPosition = new Vector2(x, y);

            // update用に取得
            transforms.Add(trans);
            startRads.Add(rad);

            str_t[i] = trans;
            str_r[i] = rad;
        }

	}

    // Update is called once per frame
    void Update()
    {

        if (onClick)
        {
            if (reset == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    transforms[i] = str_t[i];
                    startRads[i] = str_r[i];
                }
                reset = 0;
            }
            speed = 2.0f;
            time += Time.deltaTime;
            for (int i = 0; i < 2; i++)
            {
                nowRad =time * speed + startRads[i];
                Debug.Log(nowRad);
                float x_2 = Mathf.Cos(nowRad) * r[i];
                float y_2 = Mathf.Sin(nowRad) * r[i];
                transforms[i].anchoredPosition = new Vector2(x_2, y_2);

                transforms[i] = item[i].GetComponent<RectTransform>();
                startRads[i] = nowRad;
                cnt++;
            }
            if (cnt == 26) 
            {
                speed = 0f;
                time = 0;
                cnt = 0;
                reset++;
                onClick = false;
            }
        }

    }

    public void Click()
    {
        onClick = true;
    }
}
