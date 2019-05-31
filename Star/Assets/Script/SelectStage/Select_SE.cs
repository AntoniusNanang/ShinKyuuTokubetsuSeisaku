using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_SE : MonoBehaviour {

    public AudioSource audio_SE;

    public void OnClick()
    {
        audio_SE.Play();
    }
}
