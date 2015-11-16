using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using LitJson;

public class MyNetworkLobbyManager : NetworkLobbyManager
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public bool isHost { get; private set; }

    bool is_start_ = false;

    public void StartLobby()
    {
        if (is_start_) return;
        is_start_ = !is_start_;
        if (isHost)
        {
            singleton.StartHost();
        }
        else
        {
            singleton.StartClient();
        }

    }

    public void StopLobby()
    {
        if (!is_start_) return;
        is_start_ = !is_start_;
        if (isHost)
        {
            singleton.StopHost();
        }
        else
        {
            singleton.StopClient();
        }

    }

    void Start()
    {
        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        var json_data = JsonMapper.ToObject(json_text);

        singleton.networkAddress = (string)json_data["IP"];
        isHost = (bool)json_data["IsHost"];
    }
}