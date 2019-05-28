using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Select_Button : MonoBehaviour {

    public GameObject[] select;
    RectTransform[] rect = new RectTransform[2];
    float speed = 10.0f;
    bool onNextClick = false;
    bool onBackClick = false;
    float time;

	// Use this for initialization
	void Start () {
		
        for(int i = 0; i < select.Length; i++)
        {
            rect[i] = select[i].GetComponent<RectTransform>();
            Debug.Log("rect" + rect[i]);
        }

	}
	
	// Update is called once per frame
	void Update () {
        time += Time.time;
        if (onNextClick)
        {
            for (int i = 0; i < select.Length; i++)
            {
                rect[i].localPosition += new Vector3(-1.0f * speed, 0.0f, 0.0f);
                if(rect[i].localPosition.x == 0f)
                {
                    onNextClick = false;
                    break;
                }
            }
        }

        if (onBackClick)
        {
            for (int i = 0; i < select.Length; i++)
            {
                rect[i].localPosition += new Vector3(1.0f * speed, 0.0f, 0.0f);
                if (rect[i].localPosition.x == 0f)
                {
                    onBackClick = false;
                    break;
                }
            }
        }

    }

    public void nextClick()
    {
        onNextClick = true;
        Select_Zoom.click = true;
        Select_Zoom.change = false;
    }

    public void backClick()
    {
        onBackClick = true;
        Select_Zoom.click = true;
        Select_Zoom.change = false;
    }
}
