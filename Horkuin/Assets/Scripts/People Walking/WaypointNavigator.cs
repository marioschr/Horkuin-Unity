using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WaypointNavigator : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public Waypoint currentWaypoint;
    public int direction;
    private static readonly int Property = Animator.StringToHash("Move Speed");

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        direction = Random.Range(0, 2);
        navMeshAgent.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        animator.SetFloat(Property, navMeshAgent.velocity.magnitude);
        if (navMeshAgent.remainingDistance < 0.3f)
        {
            bool shouldBranch = false;

            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRation;
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
                        direction = 1;
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        direction = 0;
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                }
            }
            
            navMeshAgent.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
