﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CowsAnimationsScript : MonoBehaviour
{
    public GameObject[] positions;
    private Transform transform;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().transform.position = positions[Random.Range(0, positions.Length)].transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        transform = positions[Random.Range(0, positions.Length)].transform;
        navMeshAgent.SetDestination(transform.position);
    }
    
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.8f)
        {
            if (Random.Range(0f, 1f) < 0.2f)
            {
                animator.SetBool("Eating", true);
                navMeshAgent.speed = 0;
                Invoke("StopEating",4.042f);
            }
            else if (animator.GetBool("Eating") == false)
            {
                navMeshAgent.speed = Random.Range(0.93f, 1.05f);
                transform = positions[Random.Range(0, positions.Length)].transform;
                navMeshAgent.SetDestination(transform.position);
            }
        } else if (navMeshAgent.remainingDistance >= 0.8f && navMeshAgent.speed == 0) {
            navMeshAgent.speed = Random.Range(0.93f, 1.05f);
        }
        else {
            animator.SetFloat("Move Speed", navMeshAgent.velocity.magnitude);
        }
    }

    void StopEating(){
        animator.SetBool("Eating", false);
    }
}