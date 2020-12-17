using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;
    [SerializeField]
    private float speed;

   

    [SerializeField]
    private float yDistance;

    private bool gameOver = false;

    public Gameover GameOver;

    private void Start()
    {
        //Gaining access to Gameover class.
        GameObject gover = GameObject.FindGameObjectWithTag("Gameover");
        GameOver = gover.GetComponent<Gameover>();
    }

    private void FixedUpdate()
    {
        //Sets variable with player's location.
        playerLocation = GameObject.FindWithTag("Player").transform;
        //Sets enemy speed.
        float step = speed * Time.deltaTime;
        //Moves object toward the player's location.
        transform.position = Vector3.MoveTowards(transform.position, playerLocation.position, speed);
       
        FixPos();
      
    }


    void FixPos()
    {
        RaycastHit hit;

        //Object sends a ray downwards,
        if ((Physics.Raycast(transform.position, -Vector3.up, out hit, 10f)))
        {
            //If distance hit by ray is greater than set distance,
            if (hit.distance > yDistance)
            {
                //Object's position is set to acceptable distance.
                transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Triggers gameover upon collision with player.
        if (collision.gameObject.tag == "Player")
        {
            GameOver.gameOver = true;
            GameOver.GameOver();
        }
    }


}
