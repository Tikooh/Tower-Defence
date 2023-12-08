using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void PlayGame()
    {
        string requestedScene = "Stage1";
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(requestedScene);

    }
}
