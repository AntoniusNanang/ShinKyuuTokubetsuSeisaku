using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour {

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    public void page0()
    {
       
        stage1.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        stage2.GetComponent<RectTransform>().localPosition = new Vector3(1280, 0, 0);
        stage3.GetComponent<RectTransform>().localPosition = new Vector3(2560, 0, 0);
        stage4.GetComponent<RectTransform>().localPosition = new Vector3(3840, 0, 0);
    }
    public void page1()
    {
        FadeSystem.Fade_Image.SetActive(true);
        FadeSystem.isFade = true;
        FadeSystem.isFadeIn = true;
        stage1.GetComponent<RectTransform>().localPosition = new Vector3(-1280, 0, 0);
        stage2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        stage3.GetComponent<RectTransform>().localPosition = new Vector3(1280, 0, 0);
        stage4.GetComponent<RectTransform>().localPosition = new Vector3(2560, 0, 0);
    }

    public void page2()
    {
        stage1.GetComponent<RectTransform>().localPosition = new Vector3(-2560, 0, 0);
        stage2.GetComponent<RectTransform>().localPosition = new Vector3(-1280, 0, 0);
        stage3.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        stage4.GetComponent<RectTransform>().localPosition = new Vector3(1280, 0, 0);
    }

    public void page3()
    {
        stage1.GetComponent<RectTransform>().localPosition = new Vector3(-3840, 0, 0);
        stage2.GetComponent<RectTransform>().localPosition = new Vector3(-2560, 0, 0);
        stage3.GetComponent<RectTransform>().localPosition = new Vector3(-1280, 0, 0);
        stage4.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

}
