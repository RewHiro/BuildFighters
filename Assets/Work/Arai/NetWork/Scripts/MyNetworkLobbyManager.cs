using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkLobbyManager : NetworkLobbyManager
{

    public void LobbyStart()
    {
        Debug.Log(singleton.StartHost());
    }

    public void LobbyStop()
    {
        singleton.StopHost();
    }
}