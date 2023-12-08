using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.UIElements;

public class timer : MonoBehaviour
{
    public bool timerOn;
    public float timeLeft = 600;
    public float timeElapsed;
    public GameObject timeTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        timeElapsed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeElapsed < timeLeft)
            {
                timeElapsed += Time.deltaTime;
                updateTimer(timeElapsed);
            }
            else
            {
                Debug.Log("timer Finsihed");
                timerOn = false;
            }
        }
    }

    void updateTimer(float timeElapsed)
    {
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        timeTxt.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
