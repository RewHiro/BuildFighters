﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;

public class NetworkPlayerIdentificationer : NetworkBehaviour
{
    [SerializeField]
    string JSON_FILE_NAME = "";

    public int id { get { return id_; } }

    public void ChangeID()
    {
        if (!isLocalPlayer) return;
        ReadJson();
    }

    void Awake()
    {
        if (!isLocalPlayer) return;
        ReadJson();
    }

    void ReadJson()
    {
        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        JsonNode json = JsonNode.Parse(json_text);
        id_ = (int)json["Player"].Get<long>();
        if (id_ < 0) id_ = 0;
    }

    [SerializeField]
    int id_ = 0;
}