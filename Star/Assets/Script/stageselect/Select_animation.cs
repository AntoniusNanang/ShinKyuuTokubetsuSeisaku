using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Select_animation : MonoBehaviour {

    Animator ani;
    Animator _ani;
    bool click = false;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        _ani = GetComponent<Animator>();
      
    }
	
	// Update is called once per frame
	void Update () {
        if (click)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ani.SetBool("isShrink", true);
                ani.SetBool("isZoom", false);
                if (ani == false)
                {
                    ani.Play("shrink");
                    
                }
            }
        }

        if (ani)
        {
            ani.Play("zoom");
        }

       
    }

    public void onclick()
    {
        ani.SetBool("isZoom", true);
        ani.SetBool("isShrink", false);
        click = true;
    }
}
