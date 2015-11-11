using UnityEngine;
using System.Collections;

public class ModeTest : MonoBehaviour
{
    public void Trasition()
    {
        FindObjectOfType<SceneManager>().Trasition(SceneManager.Type.LOBBY);
    }
}