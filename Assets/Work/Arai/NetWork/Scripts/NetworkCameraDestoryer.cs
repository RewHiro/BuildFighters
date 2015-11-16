using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkCameraDestoryer : NetworkBehaviour
{
    void Update()
    {
        if (isLocalPlayer) return;
        var camera = GetComponentInChildren<Camera>();
        Destroy(camera.gameObject);
        Destroy(this);
    }
}
