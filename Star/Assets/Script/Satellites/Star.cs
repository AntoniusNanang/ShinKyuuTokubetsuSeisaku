using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    [SerializeField] GameObject GameRoot;
    [SerializeField] AudioSource audiosource;
    //光っているかフラグ
    public bool ShineFlag = false;    
    //光っていたかフラグ
    public bool beforeShineFlag = false;

    void Start() {
        GameRoot = GameObject.Find("GameRoot");
    }

    public void Shine() {
        ShineFlag = true;
        if (beforeShineFlag == false) audiosource.Play();
        GameRoot.GetComponent<GameDirector>().StarShine();
    }
    public void Lightoff() {
        beforeShineFlag = ShineFlag;
        ShineFlag = false;
        audiosource.Stop();
    }
}
