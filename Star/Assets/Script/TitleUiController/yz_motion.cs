﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yz_motion : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(1.5f, 0, 1.5f));
	}
}
