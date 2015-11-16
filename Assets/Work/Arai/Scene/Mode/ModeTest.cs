using UnityEngine;
using System.Collections;

public class ModeTest : MonoBehaviour
{
    public void Trasition()
    {
        FindObjectOfType<SceneManager>().Trasition(SceneManager.Type.LOBBY);
    }

    void Update()
    {
        if (Application.loadedLevelName != "lobby") Destroy(gameObject);
    }
}