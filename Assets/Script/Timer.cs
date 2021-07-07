using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public float gameTime=5f;

    public static bool stopTimer;

    void Start()
    {

        stopTimer = false;
        
    }

    void Update()
    {
        float time = gameTime - Time.timeSinceLevelLoad;

        int minutes = Mathf.FloorToInt(time / 60);
        if (Time.timeSinceLevelLoad>=1f)
        {
            GameManager.newGame = false;
        }
        if (time < 0)
        {
            stopTimer = true;

        }
        if (stopTimer == false)
        {
            timerText.text = time.ToString("f0");
        }
        
    }
}
