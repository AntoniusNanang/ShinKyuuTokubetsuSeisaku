using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour {

    public GameObject menu;
  
    // Use this for initialization
    void Start () {
        menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void Open()
    {
        menu.SetActive(true);
    }

    public void Close()
    {
        menu.SetActive(false);
    }
}
