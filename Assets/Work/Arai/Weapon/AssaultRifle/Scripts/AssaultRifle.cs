using UnityEngine;
using System.Collections;

public class AssaultRifle : Weapon
{

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    GameObject bullet = null;

    void Start()
    {
        bullet = FindObjectOfType<BulletCreater>().getBullet;
    }

    public override void OnAttack()
    {
        var obj = Instantiate(bullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        Vector3 force;
        force = gameObject.transform.forward * Speed;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public override void OnNotAttack()
    {
        shot_count_ = 0.0f;
    }

    float shot_count_ = 0.0f;
    int temp_count = 6;
}
