using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false; 
    float currentTime; 
    public TextMeshProUGUI currentTimeText;
    void Start()
    {
        currentTime = 0f;
        StartStopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true){
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }

    public void StartStopwatch(){
        stopwatchActive = true;
    }

    public void StopStopwatch(){
        stopwatchActive = false;

        PlayerPrefs.SetFloat("ElaspedTime", currentTime);
    }

    public float GetElapsedTime(){
        return currentTime;
    }
}
