using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ //Grabs the enemy prefab. Likely to change to an array if I believe game would benefit from multiple enemies.
    [SerializeField]
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Creates an enemy prefab.
        Instantiate(enemyPrefab);
    }

}
