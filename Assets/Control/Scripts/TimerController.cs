using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerTextTMP; // Referencia al texto UI
    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        // Iniciar timer 
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            float timeSinceStarted = Time.time - startTime;
            string timeString = FormatTime(timeSinceStarted);
            timerTextTMP.text = timeString;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private string FormatTime(float timeToFormat)
    {
        // Formatear el timer
        int minutes = (int)(timeToFormat / 60);
        int seconds = (int)(timeToFormat % 60);
        int milliseconds = (int)((timeToFormat - (seconds + minutes * 60)) * 100);

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
