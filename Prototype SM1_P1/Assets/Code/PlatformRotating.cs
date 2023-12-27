using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformRotating : MonoBehaviour
{
    
    public float ControllerSpeed;
    public float KBMSpeed;

    Rigidbody rb;


    private Vector2 moveInputValue;
    private Vector3 rotateDir;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        MoveLog();
    }


    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    private void MoveLog(){
        Vector3 result = new Vector3(moveInputValue.y,0f, -moveInputValue.x) * ControllerSpeed * Time.fixedDeltaTime;
        rb.AddTorque(result);
    }
}
