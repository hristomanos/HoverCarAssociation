using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {


    Canvas m_canvas;

	// Use this for initialization
	void Start () {
        m_canvas = GetComponent<Canvas>();
        m_canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButtonPressed();
        }
	}


   public void PauseButtonPressed()
    {
        if (m_canvas.isActiveAndEnabled)
        {
            m_canvas.enabled = false;
        }
        else
            m_canvas.enabled = true;

        Pause();
    }


    public void Pause()
    {
        //Pause the game
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


}
