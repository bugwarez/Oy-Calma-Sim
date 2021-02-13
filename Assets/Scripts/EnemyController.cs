using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject target;
    public NavMeshAgent agent;
    //public GameObject player;
    
    
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        //Gizmos.DrawCube(transform.position, Vector3.forward);
        //Gizmos.DrawWireCube(transform.position, Vector3.forward);

    }
}
