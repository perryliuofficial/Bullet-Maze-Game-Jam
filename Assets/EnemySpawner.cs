using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float secondsBetweenSpawns;
    float secondsSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceSpawn = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        secondsSinceSpawn += Time.fixedDeltaTime;
        if (secondsSinceSpawn >= secondsBetweenSpawns){
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            secondsSinceSpawn = 0;
        }
    }
}
