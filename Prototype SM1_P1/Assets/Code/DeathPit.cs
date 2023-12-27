using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPit : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Destroy(col.gameObject);
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
