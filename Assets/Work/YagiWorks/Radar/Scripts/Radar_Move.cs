using UnityEngine;
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
        if (Input.GetKey("up")|| Input.GetKey("w"))
        {
            transform.position += transform.forward ;
        }
        if (Input.GetKey("down")||Input.GetKey("s"))
        {
            transform.position -= transform.forward;
        }

        if (Input.GetKey("right")||Input.GetKey("e"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey("left")|| Input.GetKey("q"))
        {
            transform.Rotate(0, -5, 0);
        }
       
    }
}