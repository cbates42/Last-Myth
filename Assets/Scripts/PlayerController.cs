using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private float jumpForce = 25;

    [SerializeField]
    private float attackTime = 0.5f;


    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    private bool isJumping;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        //Sets inputs
        Vector3 InputDirection = new Vector3(input.x, 0, input.y);

        Vector3 cameraFlattenedForward = Camera.main.transform.forward;
        cameraFlattenedForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenedForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * InputDirection;

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(cameraRelativeInputDirection * accelerationForce, ForceMode.Acceleration);
        }

        //If space is pressed, and player isn't in the air, player will jump.
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                Jump();
            }

         
                
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
         // Temporarily calls Attack method(destroy specific gameobjects when colliding while it's active)
            Invoke("Attack", attackTime);
            attacking = false;
        }


    }


    // Update is called once per frame
    void Update()
    {
        //Sets inputs to the Horizontal and Vertical Axis
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

       
    }

    
    private void Jump()
    {
        // Sets isJumping to true, and makes player gameobject jump.
            isJumping = true;
        // rigidbody.velocity = new Vector3(0, jumpForce, 0);
        rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    private void Attack()
    {
        Debug.Log("Attacking");
        attacking = true;


    }


    // On collision with the ground or any platforms, player will regain ability to jump.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            Debug.Log("On the ground");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy")
        {
            if (attacking)
            {
                Destroy(other.gameObject);
                Debug.Log("Destroyed");
            }
        }


    }
}
