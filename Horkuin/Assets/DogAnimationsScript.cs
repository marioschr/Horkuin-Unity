using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class DogAnimationsScript : MonoBehaviour
{
    public GameObject[] positions;
    private Transform transform;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        transform = positions[Random.Range(0, positions.Length)].transform;
        navMeshAgent.SetDestination(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            transform = positions[Random.Range(0, positions.Length)].transform;
            navMeshAgent.SetDestination(transform.position);
        }
        animator.SetFloat("Move Speed", navMeshAgent.velocity.magnitude);
    }
}
