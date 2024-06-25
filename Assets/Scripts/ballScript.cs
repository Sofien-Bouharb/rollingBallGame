using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float health=100;
    public float maxHealth;
    public Image healthBar;
    public GameLogic gameLogic;
    public countdown cd;
    public Transform cam;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private float forceMult=1;

    private Camera mainCamera;
 

    audioManagerScript audioManager;

    public float turnSmoothTime = 0.1f;

     float turnSmoothVelocity;


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManagerScript>();
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHealth = health;
        mainCamera = Camera.main;
    }


    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health == 0)
        {
                cd.remainingTime = 0;
                gameLogic.gameOver();
                health += 1;
        }

    }
    private void FixedUpdate()

    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.anyKey && !gameLogic.isGameOver) {
           
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 move = Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
            rb.AddForce(move.normalized * speed,ForceMode.Force);
        }

        //to add Jump
       

    }
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        shoot(mousePressDownPos - mouseReleasePos);

    }

    void shoot(Vector3 force)
    {
        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMult);
    }
}
