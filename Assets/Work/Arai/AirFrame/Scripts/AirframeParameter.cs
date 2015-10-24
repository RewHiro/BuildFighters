using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AirframeParameter : MonoBehaviour
{

    const string JSON_PATH = "/TempResources/Json/";

    [SerializeField]
    string JSON_FILE_NAME = "";

    struct Parameter
    {
        public int id_;
        public float move_speed_;
        public float swing_speed_;
        public float boost_power_;
        public float jump_power_;
        public float max_boost_value_;
        public float max_hp_;
        public float armor_value_;
        public string name_;
        public string explanatory_text_;
    }

    Dictionary<int, Parameter> parameters_ = new Dictionary<int, Parameter>();

    void Awake()
    {
        var json_text = File.ReadAllText(Application.dataPath + JSON_PATH + JSON_FILE_NAME);
        JsonNode json = JsonNode.Parse(json_text);
        var parameters = json["Parameters"];
        foreach (var parameter in parameters)
        {
            Parameter temp_parameter;
            temp_parameter.id_ = (int)parameter["ID"].Get<long>();
            temp_parameter.move_speed_ = (float)parameter["MoveSpeed"].Get<double>();
            temp_parameter.swing_speed_ = (float)parameter["SwingSpeed"].Get<double>();
            temp_parameter.boost_power_ = (float)parameter["BoostPower"].Get<double>();
            temp_parameter.jump_power_ = (float)parameter["JumpPower"].Get<double>();
            temp_parameter.max_boost_value_ = (float)parameter["MaxBoostValue"].Get<double>();
            temp_parameter.max_hp_ = (float)parameter["MaxHP"].Get<double>();
            temp_parameter.armor_value_ = (float)parameter["ArmorValue"].Get<double>();
            temp_parameter.name_ = parameter["Name"].Get<string>();
            temp_parameter.explanatory_text_ = parameter["ExplanatoryText"].Get<string>();

            parameters_.Add(temp_parameter.id_, temp_parameter);
        }
    }
}
