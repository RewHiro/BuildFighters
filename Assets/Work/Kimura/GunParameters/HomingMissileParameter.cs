using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class HomingMissileParameter : MonoBehaviour {

    [SerializeField]
    string JSON_FILE_NAME = "";

    public string GetName(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
            homing_missile_parameter_[id].Name : ErrorMessageString(id);
    }

    public string GetExplanatoryText(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].ExplanatoryText : ErrorMessageString(id);

    }

    public float GetAttackPower(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].AttackPower : ErrorMessageFloat(id);
    }

    public float GetMaxAttackPowerRange(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].MaxAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetMinAttackPowerRange(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].MinAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetFiringSpeed(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].FiringSpeed : ErrorMessageFloat(id);
    }

    public int GetBulletsNumber(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].BulletsNumber : ErrorMessageInt(id);

    }

    public float GetBulletSpeed(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].BulletSpeed : ErrorMessageFloat(id);

    }

    public float GetReloadTime(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].ReloadTime : ErrorMessageFloat(id);

    }

    public float GetVariability(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].Variability : ErrorMessageFloat(id);

    }

    public int GetHitAccuracy(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].HitAccuracy : ErrorMessageInt(id);

    }

    float ErrorMessageFloat(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return 0.0f;
    }

    int ErrorMessageInt(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return 0;
    }


    string ErrorMessageString(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return "error";
    }

    void Awake()
    {
        JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));

        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        var json_data = JsonMapper.ToObject(json_text);
        var parameters = json_data["WeaponGatlingGunParameter"];

        for (var i = 0; i < parameters.Count; ++i)
        {
            WeaponHomingMissileParameter temp_homing_missile_parameter;

            temp_homing_missile_parameter.ID = (int)parameters[i]["ID"];
            temp_homing_missile_parameter.Name = (string)parameters[i]["Name"];
            temp_homing_missile_parameter.AttackPower = (float)(double)parameters[i]["AttackPower"];
            temp_homing_missile_parameter.MaxAttackPowerRange = (float)(double)parameters[i]["MaxAttackPowerRange"];
            temp_homing_missile_parameter.MinAttackPowerRange = (float)(double)parameters[i]["MinAttackPowerRange"];
            temp_homing_missile_parameter.FiringSpeed = (float)(double)parameters[i]["FiringSpeed"];
            temp_homing_missile_parameter.BulletsNumber = (int)parameters[i]["BulletsNumber"];
            temp_homing_missile_parameter.BulletSpeed = (float)(double)parameters[i]["BulletSpeed"];
            temp_homing_missile_parameter.ReloadTime = (float)(double)parameters[i]["ReloadTime"];
            temp_homing_missile_parameter.Variability = (float)(double)parameters[i]["Variability"];
            temp_homing_missile_parameter.HitAccuracy = (int)parameters[i]["HitAccuracy"];
            temp_homing_missile_parameter.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];

            homing_missile_parameter_.Add(temp_homing_missile_parameter.ID, temp_homing_missile_parameter);
            weapon_parameters_test_.Add(temp_homing_missile_parameter);

        }
        json_.Add("WeaponGatlingGunParameter", weapon_parameters_test_);

        string test = JsonMapper.ToJson(json_);

        Debug.Log(test);


    }

    struct WeaponHomingMissileParameter
    {
        public int ID;
        public string Name;
        public float AttackPower;
        public float MaxAttackPowerRange;
        public float MinAttackPowerRange;
        public float FiringSpeed;
        public int BulletsNumber;
        public float BulletSpeed;
        public float ReloadTime;
        public float Variability;
        public int HitAccuracy;
        public string ExplanatoryText;

    }

    Dictionary<string, List<WeaponHomingMissileParameter>> json_ = new Dictionary<string, List<WeaponHomingMissileParameter>>();
    List<WeaponHomingMissileParameter> weapon_parameters_test_ = new List<WeaponHomingMissileParameter>();
    Dictionary<int, WeaponHomingMissileParameter> homing_missile_parameter_ = new Dictionary<int, WeaponHomingMissileParameter>();

}