using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class spawningCoin : MonoBehaviour
{
    public GameObject[] obj;
    public GameLogic gameLogic;
    audioManagerScript audioManager;


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManagerScript>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
      


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            audioManager.SFXplay(audioManager.pickCoin);
            Destroy(gameObject);
            gameLogic.calcScore(1);
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-20, 20), 2, UnityEngine.Random.Range(-20, 20));
            Instantiate(gameObject, randomPosition, Quaternion.identity);
            foreach (var item in obj)
            {
                gameLogic.translateCyl(item);
            }
            

        }
    }
}   
