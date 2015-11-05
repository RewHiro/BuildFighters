using UnityEngine;
using System.Collections;

public class Bullet3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
                if (col.gameObject.tag == "enemy")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
