using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;//弾

    //ここにオブジェクトを入れる
    //いれたオブジェクトの飛ばしたい方向に対して
    //RotateはY＝180にすること
    public Transform Spawn;//弾の発射位置

    //Speedを大きくしすぎるとみえなくなるから注意
    public float Speed = 300;//速度


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shot");
            Shot();
        }
    }


    void Shot()
    {
        GameObject obj = GameObject.Instantiate(bullet) as GameObject;
        obj.transform.position = Spawn.position;
        Vector3 force;
        force = this.gameObject.transform.forward * -Speed;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

    }
}
