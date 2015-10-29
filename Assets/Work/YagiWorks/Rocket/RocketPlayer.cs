using UnityEngine;
using System.Collections;

public class RocketPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward;
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -5, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }

}