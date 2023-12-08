using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        if (!audioSource.isPlaying)
        {
        audioSource.Play();
        Debug.Log("playing");
        }

        
    }
}
