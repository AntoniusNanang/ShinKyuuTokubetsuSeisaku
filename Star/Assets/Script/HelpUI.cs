using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpUI : MonoBehaviour
{

    public GameObject help;
    bool a = false;
    void Start()
    {}
    void Update()
    {}

    public void HELP()
    {
        if (a == true)
        {
            help.SetActive(false);
            a = false;
        }
        else if (a == false)
        {
            help.SetActive(true);
            a = true;
        }
    }

    public void Back()
    {
        help.SetActive(false);
        a = false;
    }


}

