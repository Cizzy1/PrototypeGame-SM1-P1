using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformRotating : MonoBehaviour
{
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.left * RotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime);

           
        }
    }       
}
