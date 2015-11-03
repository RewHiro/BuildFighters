using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class RocketLauncherParameter : MonoBehaviour {

    [SerializeField]
    string JSON_FILE_NAME = "";

    public string GetName(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
            rocket_launcher_parameter_[id].Name : ErrorMessageString(id);
    }

    public string GetExplanatoryText(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].ExplanatoryText : ErrorMessageString(id);

    }

    public float GetAttackPower(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].AttackPower : ErrorMessageFloat(id);
    }

    public float GetMaxAttackPowerRange(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].MaxAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetMinAttackPowerRange(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].MinAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetFiringSpeed(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].FiringSpeed : ErrorMessageFloat(id);
    }

    public int GetBulletsNumber(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].BulletsNumber : ErrorMessageInt(id);

    }

    public float GetBulletSpeed(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].BulletSpeed : ErrorMessageFloat(id);

    }

    public float GetReloadTime(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].ReloadTime : ErrorMessageFloat(id);

    }

    public float GetVariability(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].Variability : ErrorMessageFloat(id);

    }

    public int GetHitAccuracy(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].HitAccuracy : ErrorMessageInt(id);

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
            WeaponRocketLauncherParameter temp_rocket_launcher_parameter_;

            temp_rocket_launcher_parameter_.ID = (int)parameters[i]["ID"];
            temp_rocket_launcher_parameter_.Name = (string)parameters[i]["Name"];
            temp_rocket_launcher_parameter_.AttackPower = (float)(double)parameters[i]["AttackPower"];
            temp_rocket_launcher_parameter_.MaxAttackPowerRange = (float)(double)parameters[i]["MaxAttackPowerRange"];
            temp_rocket_launcher_parameter_.MinAttackPowerRange = (float)(double)parameters[i]["MinAttackPowerRange"];
            temp_rocket_launcher_parameter_.FiringSpeed = (float)(double)parameters[i]["FiringSpeed"];
            temp_rocket_launcher_parameter_.BulletsNumber = (int)parameters[i]["BulletsNumber"];
            temp_rocket_launcher_parameter_.BulletSpeed = (float)(double)parameters[i]["BulletSpeed"];
            temp_rocket_launcher_parameter_.ReloadTime = (float)(double)parameters[i]["ReloadTime"];
            temp_rocket_launcher_parameter_.Variability = (float)(double)parameters[i]["Variability"];
            temp_rocket_launcher_parameter_.HitAccuracy = (int)parameters[i]["HitAccuracy"];
            temp_rocket_launcher_parameter_.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];

            rocket_launcher_parameter_.Add(temp_rocket_launcher_parameter_.ID, temp_rocket_launcher_parameter_);
            weapon_parameters_test_.Add(temp_rocket_launcher_parameter_);

        }
        json_.Add("WeaponGatlingGunParameter", weapon_parameters_test_);

        string test = JsonMapper.ToJson(json_);

        Debug.Log(test);


    }

    struct WeaponRocketLauncherParameter
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

    Dictionary<string, List<WeaponRocketLauncherParameter>> json_ = new Dictionary<string, List<WeaponRocketLauncherParameter>>();
    List<WeaponRocketLauncherParameter> weapon_parameters_test_ = new List<WeaponRocketLauncherParameter>();
    Dictionary<int, WeaponRocketLauncherParameter> rocket_launcher_parameter_ = new Dictionary<int, WeaponRocketLauncherParameter>();

}