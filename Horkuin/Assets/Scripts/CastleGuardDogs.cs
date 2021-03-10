using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGuardDogs : MonoBehaviour
{
    public GameObject[] positions;
    private Transform positionsTransform;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().transform.position = positions[Random.Range(0, positions.Length)].transform.position;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        positionsTransform = positions[Random.Range(0, positions.Length)].transform;
        navMeshAgent.SetDestination(positionsTransform.position);
    }
    
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.3f)
        {
            if (Random.Range(0f, 1f) < 0.2f)
            {
                animator.SetBool("Eating", true);
                navMeshAgent.speed = 0;
                Invoke("StopEating",4.167f);
            }
            else if (animator.GetBool("Eating") == false)
            {
                navMeshAgent.speed = Random.Range(0.85f, 1.05f);
                positionsTransform = positions[Random.Range(0, positions.Length)].transform;
                navMeshAgent.SetDestination(positionsTransform.position);
            }
        } else if (navMeshAgent.remainingDistance >= 0.3f && navMeshAgent.speed == 0) {
            navMeshAgent.speed = Random.Range(0.85f, 1.05f);
        }
        else {
            animator.SetFloat("Move Speed", navMeshAgent.velocity.magnitude);
        }
    }

    void StopEating(){
        animator.SetBool("Eating", false);
    }
}
