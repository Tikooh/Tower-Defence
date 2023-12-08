using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class onPause : MonoBehaviour
{
    public gameScriptableObject gameSO;
    public GameObject pauseScreen;

    private AudioSource[] allAudioSources;
    private bool gamePaused = false;
 
    void Start()
    {
        gameSO.gameOverEvent.AddListener(displayPause);
    }

    void displayPause()
    {
        pauseScreen.SetActive(true);
    }

    void undisplayPause()
    {
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            gameSO.Pause();
            gamePaused = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true)
        {
            gameSO.Unpause();
            gamePaused = false;
        }
    }
}
