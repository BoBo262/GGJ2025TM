using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_scene_button : MonoBehaviour
{
    public float chestCheck;
    public void Update()
    {
        if (chestCheck == 3)
            ChangeScene("Scene2");
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
