using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WaypointNavigator : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public Waypoint currentWaypoint;
    public int direction;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        navMeshAgent.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        animator.SetFloat("Move Speed", navMeshAgent.velocity.magnitude);
        if (navMeshAgent.remainingDistance < 0.3f)
        {
            bool shouldBranch = false;

            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRation ? true : false;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint
                    .branches.Count - 1)];
            }
            else
            {
                if (direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }                }
            }
            
            navMeshAgent.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
