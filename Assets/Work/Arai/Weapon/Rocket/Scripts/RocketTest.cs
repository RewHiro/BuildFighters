using UnityEngine;
using System.Collections;

public class RocketTest : Weapon
{

    GameObject bullet = null;

    void Start()
    {
        bullet = FindObjectOfType<BulletCreater>().getRocketBullet;
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            shot_count_ = 1.5f;
        }
        shot_count_ += -Time.deltaTime;
    }

    public override void OnNotAttack()
    {
        shot_count_ = 0.0f;
    }

    float shot_count_ = 0.0f;
}
