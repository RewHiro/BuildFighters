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

    public override void Attack()
    {
        var obj = Instantiate(bullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        Debug.Log(obj.transform.position);
        Vector3 force;
        force = gameObject.transform.forward * Speed;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
