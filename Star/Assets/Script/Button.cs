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

    public AudioSource audio_Button;

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
        audio_Button.Play();
        x = "reset";
        ui1();
    }

    public void selectback()
    {
        audio_Button.Play();
        x = "selectback";
        ui2();
    }

    public void yes()
    {
        audio_Button.Play();
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
        audio_Button.Play();
        n1.SetActive(false);
        n2.SetActive(false);
        b = false;
    }

    public void s_back()
    {
        audio_Button.Play();
        SceneManager.LoadScene("stageselect");
    }

    public void restart()
    {
        audio_Button.Play();
        SceneManager.LoadScene("stage");
    }

    public void n_stage()
    {
        audio_Button.Play();
        s1.X();
    }
        
}
