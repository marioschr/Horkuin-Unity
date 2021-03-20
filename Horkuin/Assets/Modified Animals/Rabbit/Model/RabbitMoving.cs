using UnityEngine;
using UnityEngine.AI;

public class RabbitMoving : MonoBehaviour
{
    public GameObject[] positions;
    private Transform positionsTransform;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private static readonly int MoveSpeed = Animator.StringToHash("Move Speed");
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.speed = Random.Range(1.55f, 2f);
        positionsTransform = positions[Random.Range(0, positions.Length)].transform;
        navMeshAgent.SetDestination(positionsTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.8f)
        {
            navMeshAgent.speed = Random.Range(1.6f, 2.05f);
            positionsTransform = positions[Random.Range(0, positions.Length)].transform;
            navMeshAgent.SetDestination(positionsTransform.position);
        }
        animator.SetFloat(MoveSpeed, navMeshAgent.velocity.magnitude);
    }
}
