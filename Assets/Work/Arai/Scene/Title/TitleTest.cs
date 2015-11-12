using UnityEngine;
using System.Collections;

public class TitleTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            FindObjectOfType<SceneManager>().Trasition(SceneManager.Type.GAME);
        }
    }
}