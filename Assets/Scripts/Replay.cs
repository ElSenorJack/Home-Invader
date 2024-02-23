using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    void Update()
    {
        if (Time.time > 15f)
        {
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;                                       
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
