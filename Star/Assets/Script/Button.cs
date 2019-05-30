using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public GameObject n;
    bool b = false;
    string x;
    delegate void MyType();
    MyType n_s;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ui()
    {
        if (b == true)
        {
            n.SetActive(false);
            b = false;
        }
        else if (b == false)
        {
            n.SetActive(true);
            b = true;
        }
    }

    public void reset()
    {
        x = "reset";
        ui();
    }

    public void selectback()
    {
        x = "selectback";
        ui();
    }

    public void yes()
    {
        if (x == "reset")
        {
            SceneManager.LoadScene("stage");
        }
        else if (x == "selectback")
        {
            SceneManager.LoadScene("stageselect");
        }
    }

    public void no()
    {
        n.SetActive(false);
        b = false;
    }

    public void s_back()
    {
        SceneManager.LoadScene("stageselect");
    }

    public void restart()
    {
        SceneManager.LoadScene("stage");
    }

    public void n_stage()
    {
     
    }
}
