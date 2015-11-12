using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkHPManager : NetworkBehaviour
{
    public float hp { private set; get; }

    void Start()
    {
        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
    }

    void OnCollisionEnter(Collision collision)
    {
        //　ダメージ処理
    }
}
