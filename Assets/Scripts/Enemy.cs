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

    private RaycastHit hit;

    [SerializeField]
    private float yDistance;

    private bool gameOver = false;

    public Gameover GameOver;

    private void Start()
    {
        GameObject gover = GameObject.FindGameObjectWithTag("Gameover");
        GameOver = gover.GetComponent<Gameover>();
    }

    private void FixedUpdate()
    {
        playerLocation = GameObject.FindWithTag("Player").transform;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerLocation.position, speed);
       
        FixPos();
      
    }


    void FixPos()
    {
        if ((Physics.Raycast(transform.position, -Vector3.up, out hit, 10f)))
        {
            if (hit.distance > yDistance)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOver.gameOver = true;
            GameOver.GameOver();
        }
    }


}
