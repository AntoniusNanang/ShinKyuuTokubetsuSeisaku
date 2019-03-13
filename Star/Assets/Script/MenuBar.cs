using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour {

    public GameObject menu;
    public GameObject menu2;
  
    // Use this for initialization
    void Start () {
        //menu.SetActive(false);
	}
    public void Open()
    {
        menu.SetActive(true);
        menu2.SetActive(true);
    }

    public void Close()
    {
        menu.SetActive(false);
        menu2.SetActive(false);
    }
}
