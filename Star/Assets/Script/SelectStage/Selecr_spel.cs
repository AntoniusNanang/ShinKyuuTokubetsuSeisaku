using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecr_spel : MonoBehaviour {

    public GameObject[] stage;
    public Transform stage_p;
    RectTransform[] trans = new RectTransform[5];

    private float speed = 2.0f;
    private float radius = 2.0f;

    float x;
    float y;

    float[] r = new float[5];
    float angle;
    float[] rad = new float[5];

    bool click = false;
    static public bool Zoom = false;

    float totalTime = 2;
    int sec;
    int cnt;

    float time  = 0;
    static public bool jug = true;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < stage.Length; i++)
        {

            stage[i].SetActive(Zoom);
            stage[i].transform.SetParent(stage_p, false);
            r[i] = stage[i].transform.localPosition.y;
            trans[i] = stage[i].GetComponent<RectTransform>();


            angle = i * (360 / stage.Length) + 90;
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
            if(jug)
            {
                time += Time.deltaTime;
                totalTime -= Time.deltaTime;
                sec = (int)totalTime;

                for (int i = 0; i < stage.Length; i++)
                {
                    x = r[i] * Mathf.Cos(time * speed + rad[i]);
                    y = r[i] * Mathf.Sin(time * speed + rad[i]);
                    stage[i].transform.localPosition = new Vector3(x, y, 0.0f);
                    cnt++;
                    
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
                Debug.Log(jug);
                
            }
            
        }
        if (!jug)
        {
            time = 0;
        }
        
    }

    public void onClick()
    {
        click = true;
        speed = 2;
        totalTime = 3;
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].SetActive(Zoom);
        }
    }
}
