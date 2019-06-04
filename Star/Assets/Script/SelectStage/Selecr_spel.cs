using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecr_spel : MonoBehaviour {

    public GameObject[] stage;
    public Transform stage_p1;
    public Transform stage_p2;
    public Transform stage_p3;

    RectTransform[] trans = new RectTransform[5];

    private float speed = 2.0f;
    private float radius = 2.0f;

    float x;
    float y;

    float[] r = new float[15];
    float angle;
    float[] rad = new float[15];

    bool click = false;
    static public bool Zoom = false;

    float totalTime = 2;
    int sec;
    int cnt;

    float time  = 0;
    static public bool jug = true;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < 5; i++)
        {

            stage[i].SetActive(Zoom);
           
            stage[i].transform.SetParent(stage_p1, false);
            r[i] = stage[i].transform.localPosition.y;
           


            angle = i * (360 / 5) + 90;
            rad[i] = angle * Mathf.Deg2Rad;
            x = Mathf.Cos(rad[i]) * r[i];
            y = Mathf.Sin(rad[i]) * r[i];

            stage[i].transform.localPosition = new Vector3(x, y, 0.0f);

        }

        for(int i = 5; i < 10; i++)
        {
            stage[i].SetActive(Zoom);

            stage[i].transform.SetParent(stage_p2, false);
            r[i] = stage[i].transform.localPosition.y;



            angle = i * (360 / 5) + 90;
            rad[i] = angle * Mathf.Deg2Rad;
            x = Mathf.Cos(rad[i]) * r[i];
            y = Mathf.Sin(rad[i]) * r[i];

            stage[i].transform.localPosition = new Vector3(x, y, 0.0f);
        }
        for (int i = 10; i < 15; i++)
        {
            stage[i].SetActive(Zoom);

            stage[i].transform.SetParent(stage_p3, false);
            r[i] = stage[i].transform.localPosition.y;
           


            angle = i * (360 / 5) + 90;
            rad[i] = angle * Mathf.Deg2Rad;
            x = Mathf.Cos(rad[i]) * r[i];
            y = Mathf.Sin(rad[i]) * r[i];

            stage[i].transform.localPosition = new Vector3(x, y, 0.0f);
        }



    }
	
	// Update is called once per frame
	void Update () {

        if (click)
        {
            if (jug)
            {
                time += Time.deltaTime;
                totalTime -= Time.deltaTime;
                sec = (int)totalTime;

                for (int i = 0; i < stage.Length; i++)
                {
                    x = r[i] * Mathf.Cos(time * speed + rad[i]);
                    y = r[i] * Mathf.Sin(time * speed + rad[i]);
                    stage[i].transform.localPosition = new Vector3(x, y, 0.0f);

                }
                
                if (sec <= 0)
                {
                    speed = speed * 0.98f;

                    if (speed <= 0.01f)
                    {
                        speed = 0;
                        time = 0;
                        click = false;
                        jug = false;

                    }
                    totalTime = 0;
                    sec = 0;
                }

            }

        }
        if (!jug)
        {
            time = 0;
        }
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].SetActive(Zoom);
        }

    }

    public void onClick()
    {
        click = true;
        speed = 2;
        totalTime = 3;
        
    }
}
