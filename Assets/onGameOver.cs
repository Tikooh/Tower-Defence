using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class onGameOver : MonoBehaviour
{
    public gameScriptableObject gameSO;
    public GameObject gameOverScreen;
    public AudioSource gameOverAudioSource;
    public AudioClip gameOverSound;

    private AudioSource[] allAudioSources;
 
    void Start()
    {
        gameSO.gameOverEvent.AddListener(displayGameOver);
    }

    void displayGameOver()
    {
        StopAllAudio();
        gameOverAudioSource.PlayOneShot(gameOverSound);
        gameOverScreen.SetActive(true);
    }
    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audios in allAudioSources) {
            audios.Stop();
        }
    }
}
