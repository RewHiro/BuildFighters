using UnityEngine;
using System.Collections;

public class BulletCreater : MonoBehaviour
{
    [SerializeField]
    GameObject assalut_bullet_ = null;

    public GameObject getBullet
    {
        get
        {
            return assalut_bullet_;
        }
    }
}
