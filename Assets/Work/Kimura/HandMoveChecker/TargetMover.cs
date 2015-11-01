using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward;
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -5, 0);
        }

    }
}