using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Force of acceleration
    [SerializeField]
    private float accelerationForce = 10;

    // Max speed
    [SerializeField]
    private float maxSpeed = 2;

    // Jump height
    [SerializeField]
    private float jumpForce = 25;

    //How long an attack stays active for
    [SerializeField]
    private float attackTime = 0.5f;


    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    private bool isJumping;
    private bool attacking;
    private bool hoverHold;

    [SerializeField]
    private GameObject weaponPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //Grants access to the rigidbody and collider of attached gameobject
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

        //Rotate input direction to be relative to the camera
        Vector3 cameraRelativeInputDirection = cameraRotation * InputDirection;

        //If speed isn't at max, continue to accelerate
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(cameraRelativeInputDirection * accelerationForce, ForceMode.Acceleration);
        }

       


    }


    // Update is called once per frame
    void Update()
    {
        //Sets inputs to the Horizontal and Vertical Axis
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

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
            Attack();

        }


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
        Instantiate(weaponPrefab);
      


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
        //Upon collision, 
       if(other.gameObject.tag == "Enemy")
        { //if colliding entity has Enemy tag,
            if (attacking)
            { //and if player is attacking (attacking is true), destroy that gameObject and log it in console.
                Destroy(other.gameObject);
                Debug.Log("Destroyed");
            }
        }


    }
}
