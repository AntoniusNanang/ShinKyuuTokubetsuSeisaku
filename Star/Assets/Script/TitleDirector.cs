using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

    public string nameScene;
    public AudioSource[] audio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            audio[0].volume = 0.4f;
            audio[1].Play();
            Invoke("SceneMove", 4);
        }

	}

    void SceneMove()
    {
        SceneManager.LoadScene(nameScene);
    }
}
