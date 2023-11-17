using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformRotating : MonoBehaviour
{
    //public float RotateSpeed;
    Rigidbody rb;
    public float Torque;

    PlayerControls controls;

    void Awake(){
        controls = new PlayerControls();

        controls.Gameplay.Movement.performed += ctx => rotate();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Input.GetKey(KeyCode.A)){
            //transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
            rb.AddTorque(transform.right * Torque);
        }

        if(Input.GetKey(KeyCode.D)){
            //transform.Rotate(Vector3.left * RotateSpeed * Time.deltaTime);
            rb.AddTorque(-transform.right * Torque);
        }

        if(Input.GetKey(KeyCode.W)){
            //transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
            rb.AddTorque(transform.forward * Torque);
        }

        if(Input.GetKey(KeyCode.S)){
            //transform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime);
            rb.AddTorque(-transform.forward * Torque);
           
        }
    }

    void rotate(){
        rb.AddTorque(transform.forward * Torque)''
    }

    void OnEnable(){
        controls.Gameplay.Enable();
    }

    void OnDisable(){
        controls.Gameplay.Disable();
    }

    
}
