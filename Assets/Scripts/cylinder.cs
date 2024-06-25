using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cylinder : MonoBehaviour
{
    public float damage = 20;
    public GameLogic gameLogic;

    audioManagerScript audioManager;
    public ParticleSystem explosion;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManagerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           


    }   


  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
           

            if (gameLogic.score > 0)
            {
                gameLogic.calcScore(-1);
            }


            gameLogic.changeHealth(-damage);

            audioManager.SFXplay(audioManager.collision);
            Instantiate(explosion, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
            gameLogic.translateCyl(gameObject);
            /*Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-20, 20), -1.6f, UnityEngine.Random.Range(-20, 20));
            transform.position =randomPosition;*/

        }
    }
}
