using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopPlayGame : MonoBehaviour
{
 private bool _isPaused = false;

    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0f; // Остановка времени
        }
        else
        {
            Time.timeScale = 1f; // Возобновление времени
        }
    }
}
