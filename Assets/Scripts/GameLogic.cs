using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    
    public int score = 0;
    public GameObject text;
    public static Text scoreText;
    public GameObject gameOverUi;
    public GameObject affScore;
    public Text scoreAff;
    public ballScript ballHealth;
    public GameObject hScore;
    public Text highScore;
    public static int maxScore=0;
    public int highestScore=66;
    public bool isGameOver=false;
    int vrf = 0;
    audioManagerScript audioManager;


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManagerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = text.GetComponent<Text>();
        highScore = hScore.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
      

    }
    public void calcScore(int val)
    {   
        score = score + val;
        if (score % 5 == 0 && score>vrf && ballHealth.health<100)
        {
            changeHealth(20);
            vrf = score;
            audioManager.SFXplay(audioManager.powerUp);
            Debug.Log(ballHealth.health);
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void translateCyl( GameObject obj)
    {
        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-20, 20), -1.6f, UnityEngine.Random.Range(-20, 20));
        obj.transform.position = randomPosition;
    }
   public void gameOver()
    {
       
        
            audioManager.musicStop();
            audioManager.SFXplay(audioManager.gameOver);
            scoreAff = affScore.GetComponent<Text>();
            //Cursor.lockState = CursorLockMode.None;
            scoreAff.text = "Your score is: " + score.ToString();
            int k = loadData();
    

            if (k < score)
            {
                highestScore = score;
 
                saveData(highestScore);
            }
        isGameOver = true;
            highScore.text = "Your highest score is: " + loadData();
            gameOverUi.SetActive(true);    
        
       
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeHealth(float ch)
    {
        ballHealth.health += ch;
    }

    public void saveData(int x)
    {
        PlayerPrefs.SetInt("score", x);
    }
    public int loadData()
    {
        return PlayerPrefs.GetInt("score");
    }
}