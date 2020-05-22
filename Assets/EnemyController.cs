using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent agent;
    //public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        // Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        // Vector3 vectorToPlayer = player.transform.position - transform.position;
        // ourRigidBody.velocity = vectorToPlayer.normalized * enemySpeed;

    }
}
