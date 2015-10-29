using UnityEngine;

using System.Collections;

public class Rocket : MonoBehaviour
{

    float bulletSpeed = 0.0f;

    public float life_time = 1.5f;
    float time = 0f;

    // Use this for initialization
    void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, bulletSpeed * bulletSpeed);
        bulletSpeed += 0.016f;
    }
}