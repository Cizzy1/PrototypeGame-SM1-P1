using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformRotating : MonoBehaviour
{
    public float RotateSpeed;
    Rigidbody rb;
    public float Torque;

    private Vector2 moveInputValue;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        MoveLog();

        /* if(Input.GetKey(KeyCode.A)){
            //transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
            rb.AddTorque(transform.right * Torque);
        }

        if(Input.GetKey(KeyCode.D)){
            //transform.Rotate(Vector3.left * RotateSpeed * Time.deltaTime);
            rb.AddTorque(-transform.right * Torque);
        }

        if(Input.GetKey(KeyCode.W) or Gamepad.current.LeftStick)
        {
            //transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
            rb.AddTorque(transform.forward * Torque);
        }

        if(Input.GetKey(KeyCode.S))
        {
            //transform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime);
            rb.AddTorque(-transform.forward * Torque);
           
        } */
    }

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    private void MoveLog(){
        Vector3 result = new Vector3(moveInputValue.x,0f,moveInputValue.y ) * RotateSpeed * Time.fixedDeltaTime;
        rb.velocity = -result;

        /* float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); */
    }    
}
