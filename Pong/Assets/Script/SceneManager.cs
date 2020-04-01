using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Somewhat didn't load the SceneManager
// using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void MainMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }
}
