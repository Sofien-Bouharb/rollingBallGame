using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

using UnityEngine.SceneManagement;


public class countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime=180;
    public GameLogic gameLogic;
    audioManagerScript audioManager;


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime<0)
        {
            remainingTime = 0;
            
            gameLogic.gameOver();

        }
       
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
