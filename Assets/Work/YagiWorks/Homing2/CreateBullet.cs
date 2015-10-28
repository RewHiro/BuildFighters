using UnityEngine;
using System.Collections;

public class CreateBullet : MonoBehaviour {

    public GameObject bullet;
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("space")) Instantiate(bullet, transform.position, transform.rotation);

    }
}
