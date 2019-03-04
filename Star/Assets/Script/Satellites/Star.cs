using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    [SerializeField] GameObject GameRoot;
    //光っているかフラグ
    public bool ShineFlag = false;

    void Start() {
        GameRoot = GameObject.Find("GameRoot");
    }

    public void Shine() {
        ShineFlag = true;
        GameRoot.GetComponent<GameDirector>().StarShine();
    }
    public void Lightoff() {
        ShineFlag = false;
    }
}
