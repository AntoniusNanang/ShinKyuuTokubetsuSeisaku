using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour {

    
    public Animator animator;
    bool click = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnClick();
        }
    }

    public void OnClick()
    {
        if (click)
        {
            animator.SetBool("MenuBar", true);
            click = false;
            Debug.Log(1);
        }
        else
        {
            animator.SetBool("MenuBar", false);
            click = true;
            Debug.Log(0);

        }
    }
}
