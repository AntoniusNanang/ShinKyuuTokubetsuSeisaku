using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public GameObject n1;
    public GameObject n2;
    public GameObject n3;

    bool b = false;
    string x;
    GameObject game;
    s1 script;

    // Use this for initialization
    void Start () {
        game = GameObject.Find("GameRoot");
        script = game.GetComponent<s1>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ui1()
    {
        if (b == true)
        {
            n1.SetActive(false);
            b = false;
        }
        else if (b == false)
        {
            n1.SetActive(true);
            b = true;
        }
    }
    public void ui2()
    {
        if (b == true)
        {
            n2.SetActive(false);
            b = false;
        }
        else if (b == false)
        {
            n2.SetActive(true);
            b = true;
        }
    }
    public void ui3()
    {
        if (b == true)
        {
            n3.SetActive(false);
            b = false;
        }
        else if (b == false)
        {
            n3.SetActive(true);
            b = true;
        }
    }

    public void reset()
    {
        x = "reset";
        ui1();
    }

    public void selectback()
    {
        x = "selectback";
        ui2();
    }

    public void yes()
    {
        if (x == "reset")
        {
            SceneManager.LoadScene("stage");
            FadeSystem.isFade = true;
            FadeSystem.isFadeOut = true;
        }
        else if (x == "selectback")
        {
            SceneManager.LoadScene("stageselect");
        }
    }

    public void no()
    {
        n1.SetActive(false);
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
        script.X();
    }
        
}
