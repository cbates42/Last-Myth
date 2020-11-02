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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        playerLocation = GameObject.FindWithTag("Player").transform;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerLocation.position, speed);
        FixPos();
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.Quit();
            Debug.Log("Game Over");
        }
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
}
