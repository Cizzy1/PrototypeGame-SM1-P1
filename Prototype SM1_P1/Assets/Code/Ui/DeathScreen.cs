using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Update(){
        if(Gamepad.current.buttonWest.IsPressed()){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    public void Quit()
    {
        Application.Quit(); 
        Debug.Log("Game Quit");
    }
}
