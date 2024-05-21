using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenneLoader 
{
    public static void ReloadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(index);
    }

    public static void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index>=SceneManager.sceneCount)
        {
            //
        }

        SceneManager.LoadScene(index);
    }

    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else   
        Application.Quit();      
    #endif
    }

    
}
