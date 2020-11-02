using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{

    public bool gameOver = false;



    private void OnTriggerEnter(Collider other)
    {   //When player enters, game over set to true.
            if (other.CompareTag("Player"))
            {
            gameOver = true;
            GameOver();
            }
        
    }

    public void GameOver()
    {
        if(gameOver)
        { //Placeholder, will be replaced with a UI gameover.
            Debug.Log("Game over!");
        }
    }    
}
