using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour {

    public Image FadeImage;
    public string SceneName;

    public static bool isFade;
    public static bool isFadeIn;
    public static bool isFadeOut;

    float alpha;

	// Use this for initialization
	void Start () {

        alpha = 1.0f;
        isFade = true;
        isFadeIn = true;
        isFadeOut = false;

        transform.SetAsFirstSibling();
	}
	
	// Update is called once per frame
	void Update () {
        if (isFade)
        {
            if (isFadeIn)          FadeIn();
            else if (isFadeOut)    FadeOut();
        }
	}

    void FadeIn()
    {
        alpha -= 0.05f;
        FadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        if(alpha <= 0.0f)
        {
            isFade = false;
            isFadeIn = false;

            transform.SetAsLastSibling();
        }
    }

    void FadeOut()
    {
        alpha += 0.05f;
        FadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        if(alpha >= 1.0f)
        {
            isFade = false;
            isFadeOut = false;

            //SceneManager.LoadScene(SceneName);
        }
    }
}
