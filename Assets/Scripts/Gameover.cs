using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{

    public bool gameOver = false;



    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
            gameOver = true;
            GameOver();
            }
        
    }

    public void GameOver()
    {
        if(gameOver)
        {
            Debug.Log("Game over!");
        }
    }    
}
