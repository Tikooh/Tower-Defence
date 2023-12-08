using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class onPause : MonoBehaviour
{
    public gameScriptableObject gameSO;
    public GameObject pauseScreen;
    private bool gamePaused;
 
    void Start()
    {
        gamePaused = false;
        gameSO.pauseEvent.AddListener(displayPause);
        gameSO.unpauseEvent.AddListener(undisplayPause);
    }

    void displayPause()
    {
        Debug.Log("displayMenu");
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void undisplayPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            Debug.Log("escape presseed");
            gameSO.Pause();
            gamePaused = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true)
        {
            Debug.Log("escape Unpressed");
            gameSO.Unpause();
            gamePaused = false;
        }
    }
}
