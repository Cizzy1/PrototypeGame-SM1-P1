using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Destroy(col.gameObject);
    }
}
