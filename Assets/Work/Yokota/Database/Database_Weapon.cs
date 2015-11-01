using UnityEngine;
using System.Collections;
using MiniJSON;
using System.IO;

public class Database_Weapon : MonoBehaviour
{
    /// <summary>
    /// 武器
    /// </summary>
    #region
    [SerializeField, Tooltip("発射速度")]
    public float LUANCH_SPEED = 0.0f;

    [SerializeField, Tooltip("弾数")]
    public int BULLET_AMOUNT;

    [SerializeField, Tooltip("弾の速度")]
    public float BULLET_SPEED;

    [SerializeField, Tooltip("リロード時間")]
    public float RELOAD_TIME;

    [SerializeField, Tooltip("最大攻撃力")]
    public float WAPON_ATTACKPOWER_MAX;
    
    [SerializeField,Tooltip("最小攻撃力")]
    public float WAPON_ATTACKPOWER_MIN;
    #endregion

    void Awake()
    {
        var textAsset = Resources.Load("Json/test") as TextAsset;
        JsonNode json = JsonNode.Parse(textAsset.text);


        LUANCH_SPEED = (float)json["Luanch_Speed"].
            Get<double>();
        BULLET_AMOUNT = (int)json["Bullet_Amount"].
            Get<long>();
        BULLET_SPEED = (float)json["Bullet_Speed"].
            Get<double>();
        RELOAD_TIME = (float)json["Reload_Time"].
            Get<double>();
        WAPON_ATTACKPOWER_MAX
            = (float)json["Wapon_AttackPower_Max"].Get<double>();
        WAPON_ATTACKPOWER_MIN
            = (float)json["Wapon_AttackPower_Min"].Get<double>();

    }

}
