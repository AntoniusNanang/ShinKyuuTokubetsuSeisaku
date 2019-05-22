using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_rotation : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //rotation Y を0～360まで回して360になったら0にする

        {
            transform.Rotate(new Vector3(0, 0, 0.05f));
        }
	}
}
