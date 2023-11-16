using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    Rigidbody rb;
    private GameObject target;
    public float ForceAmount = 40f;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
        this.transform.LookAt(target.transform.position);
        rb.AddForce(transform.up * ForceAmount);
    }
}
