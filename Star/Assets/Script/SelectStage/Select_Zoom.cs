using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Zoom : MonoBehaviour {

    public GameObject[] button;
    RectTransform[] rect = new RectTransform[3];
    static public bool click = false;
    static public bool change = true;
    static public bool judg = false;

    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            rect[i] = button[i].GetComponent<RectTransform>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (click)
        {
           
            if (change)
            {
                Selecr_spel.jug = true;
                click = false;
                StartCoroutine(changeButtonBigSize());
                change = false;
                judg = true; 
            }
            else if (!change)
            {
                Selecr_spel.jug = false;
                click = false;
                StartCoroutine(changeButtonSmallSize());
                change = true;
                judg = false;
            }
           
        }

        if (judg)
        {
            Selecr_spel.Zoom = true;

        }
        else if (!judg)
        {
            Selecr_spel.Zoom = false;
        }
        


    }

    public void onClick()
    {
        click = true;
        audio.Play();
    }

    IEnumerator changeButtonBigSize()
    {
        var size = 0f;
        var speed = 0.03f;
       

        while (size <= 1.0f)
        {
            for (int i = 0; i < rect.Length; i++)
            {
                rect[i].localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(2, 2, 2), size);
            }
            size += speed;

            yield return null;
        }

    }

    IEnumerator changeButtonSmallSize()
    {
        var size = 0f;
        var speed = 0.03f;

        while (size <= 1.0f)
        {
            for (int i = 0; i < rect.Length; i++)
            {
                rect[i].localScale = Vector3.Lerp(new Vector3(2, 2, 2), new Vector3(1, 1, 1), size);
            }
            size += speed;

            yield return null;
        }
    }
}
