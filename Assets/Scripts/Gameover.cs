using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        { //Sends player to Gameover scene
            Debug.Log("Game over!");
            SceneManager.LoadScene("GameOver");
        }
    }    
}
