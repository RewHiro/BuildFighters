using UnityEngine;

using System.Collections;

public class Rocket : MonoBehaviour
{

    float bulletSpeed = 0.0f;

    public float life_time = 1.5f;
    float time = 0f;

    private int movecount = 0;

    // Use this for initialization
    void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (movecount < 30) bulletSpeed = movecount * 0.01f;
        else bulletSpeed += bulletSpeed * 0.6f;

        movecount++;

        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, bulletSpeed);
    }
}