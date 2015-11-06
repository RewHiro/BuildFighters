using UnityEngine;
using System.Collections;

public class BulletY : MonoBehaviour
{


    private Database_Weapon _database_weapon;



    [SerializeField]
    private GameObject bullet;//弾


    /// <summary>
    ///ここにオブジェクトを入れる 
    /// いれたオブジェクトの飛ばしたい方向に対して
    /// RotateはY＝180にすること
    /// </summary>
    public Transform Spawn;//弾の発射位置



    /// <summary>
    /// 発射間隔
    /// </summary>
    [SerializeField, Tooltip("発射間隔(falseなら発射できる)")]
    private bool InertvalBool = false;
    [SerializeField, Tooltip("発射間隔(0なら発射できる)")]
    private float IntervalTime = 0;
    [SerializeField, Tooltip("発射間隔")]
    private float Interval;


    /// <summary>
    /// 弾数
    /// WeaponNumberとWeaponNumberは同じ数を入力してください
    /// </summary>
    [SerializeField, Tooltip("弾数（0になると打てなくなります）")]
    private int WeaponNumber;//= 10;
    [SerializeField, Tooltip("弾数")]
    private int WeaponNumberMax;

    /// <summary>
    /// 弾の速度
    /// Speedを大きくしすぎるとみえなくなるから注意
    /// </summary>
    [SerializeField, Tooltip("弾の速度")]
    private float Speed;//

    /// <summary>
    /// リロード
    /// </summary>
    //[SerializeField, Tooltip("リロード時間")]
    //private const float ReloadTime;
    [SerializeField]
    private float ReloadTimeS; //= ReloadTime;
    [SerializeField]
    private float ReloadTimeFirst;  //= ReloadTime;
    [SerializeField]
    private bool ReloadBool = false;

    void Start()
    {
        _database_weapon = FindObjectOfType<Database_Weapon>();

        Interval = _database_weapon.INTERVAL_SPEED;
        WeaponNumber = _database_weapon.BULLET_AMOUNT;
        WeaponNumberMax = _database_weapon.BULLET_AMOUNT;
        Speed = _database_weapon.BULLET_SPEED;
        ReloadTimeS = _database_weapon.RELOAD_TIME;
        ReloadTimeFirst = _database_weapon.RELOAD_TIME;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) &&
            (InertvalBool == false) &&
            (WeaponNumber >= 1))
        {
            InertvalBool = true;
            WeaponNumber--;
            Debug.Log("Shot");
            Shot();
        }

        //発射間隔
        if (InertvalBool == true) { IntervalTime++; }
        if (IntervalTime >= Interval) { InertvalBool = false; IntervalTime = 0; }

        //リロードする
        if (Input.GetKeyDown(KeyCode.Z) && ReloadBool == false)
        { ReloadBool = true; }
        if (ReloadBool == true) { ReloadTimeS--; }
        if ((ReloadBool == true) && ReloadTimeS <= 0)
        {
            ReloadBool = false;
            ReloadTimeS = ReloadTimeFirst;
            WeaponNumber = WeaponNumberMax;
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
