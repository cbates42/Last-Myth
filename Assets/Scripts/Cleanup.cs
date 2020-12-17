using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   //When player enters, game over set to true.
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

    }
}
