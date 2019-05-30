﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_button : MonoBehaviour {

    public GameObject[] select;
    RectTransform[] rect = new RectTransform[3];
    float speed = 10.0f;
    bool Move = false;
    bool onNextClick = false;
    bool onBackClick = false;
    float time;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < select.Length; i++)
        {
            rect[i] = select[i].GetComponent<RectTransform>();
            Debug.Log("rect" + rect[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.time;
        
        if (onNextClick)
        {
            Selecr_spel.Zoom = false;
            Debug.Log(Selecr_spel.Zoom);
            if (!Move)
            {
                for (int i = 0; i < select.Length; i++)
                {
                    rect[i].localPosition += new Vector3(-1.0f * speed, 0.0f, 0.0f);
                    if (rect[i].localPosition.x == 0f)
                    {
                        onNextClick = false;
                        Debug.Log(speed);
                        Move = true;
                    }
                    if (rect[2].localPosition.x == 0)
                    {
                        speed = 0;

                    }
                }

            }
        }
        if (rect[0].localPosition.x == 0)
        {
            speed = 0;
        }
        if (onBackClick)
        {
            Selecr_spel.Zoom = false;
            Debug.Log(Selecr_spel.Zoom);
            if (Move)
            {
                for (int i = 0; i < select.Length; i++)
                {
                    rect[i].localPosition += new Vector3(1.0f * speed, 0.0f, 0.0f);

                    if (rect[i].localPosition.x == 0f)
                    {
                        onBackClick = false;
                        Move = false;
                    }

                }
            }
        }

    }

    public void nextClick()
    {
        onNextClick = true;
        Move = false;
        speed = 10;
        
        if (Select_Zoom.judg == true)
        {
            Select_Zoom.click = true;
            Select_Zoom.change = false;
            Select_Zoom.judg = true;
        }
    }

    public void backClick()
    {
        onBackClick = true;
        Move = true;
        speed = 10;
      
        if (Select_Zoom.judg == true)
        {
            Select_Zoom.click = true;
            Select_Zoom.change = false;
            Select_Zoom.judg = true;
        }

    }
}