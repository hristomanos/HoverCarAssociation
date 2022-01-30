using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonOptions : MonoBehaviour {

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //Player Selection buttons

    public void Player1()
    {
        SceneManager.LoadScene(2);
    }

    public void Player2()
    {
        SceneManager.LoadScene(3);
    }


    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else    
            Application.Quit();
        #endif
    }

}
