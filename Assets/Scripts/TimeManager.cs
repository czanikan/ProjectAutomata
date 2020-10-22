using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public GameObject PauseButton, StartButton, SpeedUpButton;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StopTime();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            NormalSpeed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DoubleSpeed();
        }
    }

    public void StopTime()
    {

        Time.timeScale = 0;

        PauseButton.GetComponent<Image>().color = Color.green;
        StartButton.GetComponent<Image>().color = Color.white;
        SpeedUpButton.GetComponent<Image>().color = Color.white;
    }

    public void NormalSpeed()
    {
        Time.timeScale = 1;

        PauseButton.GetComponent<Image>().color = Color.white;
        StartButton.GetComponent<Image>().color = Color.green;
        SpeedUpButton.GetComponent<Image>().color = Color.white;
    }

    public void DoubleSpeed()
    {
        Time.timeScale = 2;

        PauseButton.GetComponent<Image>().color = Color.white;
        StartButton.GetComponent<Image>().color = Color.white;
        SpeedUpButton.GetComponent<Image>().color = Color.green;
    }
}
