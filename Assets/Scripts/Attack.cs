using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If weaponPrefab comes into contact with Enemy, destroys enemy.
      if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
