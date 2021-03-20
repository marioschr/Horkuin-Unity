using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class DogAnimationsScript : MonoBehaviour
{
    public GameObject[] positions;
    private Transform transform;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private static readonly int MoveSpeed = Animator.StringToHash("Move Speed");

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.speed = Random.Range(0.85f, 1.05f);
        transform = positions[Random.Range(0, positions.Length)].transform;
        navMeshAgent.SetDestination(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.8f)
        {
            navMeshAgent.speed = Random.Range(0.85f, 1.05f);
            transform = positions[Random.Range(0, positions.Length)].transform;
            navMeshAgent.SetDestination(transform.position);
        }
        animator.SetFloat(MoveSpeed, navMeshAgent.velocity.magnitude);
    }
}
