using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Movement
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision thiscollision) {
        GameObject theirGameObject = thiscollision.gameObject;
        if (theirGameObject.GetComponent<EnemyController>() != null) {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            theirHealthSystem.TakeDamage(1);
            Destroy(gameObject);
        };
    }
}
