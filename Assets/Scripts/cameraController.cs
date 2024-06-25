using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
    
{
    public Vector2 turn;
    public GameObject player;
    public  Vector3 offset;
    public float sensetivity = 0.5f;
    public float pLerp=.02f;
    public float rLerp=.01f;
    // Start is called before the first frame update
    void Start()
    {
       //offset = transform.position - player.transform.position; 
       Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        // turn.x += Input.GetAxis("Mouse X")*sensetivity;
        // turn.y += Input.GetAxis("Mouse Y")*sensetivity;
        // transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        
        //transform.position = Vector3.Lerp(transform.position, player.transform.position, pLerp);
        ///*transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, rLerp);*/


    }

    void LateUpdate()
    {
       //transform.position = player.transform.position+offset;
    }
}
