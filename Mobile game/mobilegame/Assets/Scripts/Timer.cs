using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text textBox;
    public Text startBtnText;
    bool timerActive = true;

    void Start()
    {
        textBox.text = ": " + timeStart.ToString("F0");
    }

    void Update()
    {
        if (timerActive)
        {
            Time.timeScale = 1;
            timeStart += Time.deltaTime;
            textBox.text = ": " + timeStart.ToString("F0");
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void timerButton()
    {
        timerActive = !timerActive;
        startBtnText.text = timerActive ? "" : "";
    }
}