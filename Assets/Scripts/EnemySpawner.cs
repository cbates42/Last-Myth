using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
