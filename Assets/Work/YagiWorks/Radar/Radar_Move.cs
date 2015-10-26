﻿using UnityEngine;
using System.Collections;

public class Radar_Move : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward ;
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -5, 0);
        }
    }
}