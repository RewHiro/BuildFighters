using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkBoostManager : NetworkBehaviour
{
    public float boostValue { private set; get; }

    void Start()
    {
        if (!isLocalPlayer) return;
        var id = GetComponent<NetworkPlayerIdentificationer>().id;
        boostValue = FindObjectOfType<AirFrameParameter>().GetMaxBoostValue(id);
    }
}
