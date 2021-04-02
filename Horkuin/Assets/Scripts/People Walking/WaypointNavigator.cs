using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WaypointNavigator : MonoBehaviour
{
    //private WaypointNavigator wayNav;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public Waypoint currentWaypoint;
    public int direction;
    private static readonly int MoveSpeed = Animator.StringToHash("Move Speed");
    private bool firstTime = true;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentWaypoint == null) return;
        if (firstTime)
        {
            navMeshAgent.SetDestination(currentWaypoint.GetPosition());
            firstTime = false;
        }
        if (Vector3.Distance(transform.position, currentWaypoint.GetPosition()) < 1f) // Αν έχει πλησιάσει τον στόχο
        {
            navMeshAgent.speed = Random.Range(0.90f, 1.1f); // Αλλαγή ταχύτητας
            bool shouldBranch = false;

            // Έλεγχος για διακλάδωση
            
            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRation;
            }

            if (shouldBranch) // Επιλέγει να αλλάξει δρόμο
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint
                    .branches.Count - 1)];
            }
            else // Διαφορετικά συνεχίζει
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
        animator.SetFloat(MoveSpeed, navMeshAgent.velocity.magnitude);
    }
}
