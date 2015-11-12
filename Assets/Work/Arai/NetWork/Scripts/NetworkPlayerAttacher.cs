using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerAttacher : NetworkBehaviour
{

    [SerializeField]
    GameObject right_weapon_ = null;

    [SerializeField]
    GameObject left_weapon_ = null;

    public Weapon getRightWeapon
    {
        get
        {
            return right_weapon_.GetComponent<Weapon>();
        }
    }

    public Weapon getLeftWeapon
    {
        get
        {
            return left_weapon_.GetComponent<Weapon>();
        }
    }

    void Awake()
    {
        right_weapon_.AddComponent<AssaultRifle>();
        left_weapon_.AddComponent<RocketTest>();
    }
}
