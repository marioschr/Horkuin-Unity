using UnityEngine;
using UnityEngine.AI;

public class CastleBarkingTrigger : MonoBehaviour
{
    public GameObject dogsPosition, dog1, dog2;
    public Transform position1, position2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Animal"))
        {
            if (dog1.GetComponent<Animator>().GetBool("Eating"))
            {
                dog1.GetComponent<Animator>().SetBool("Eating", false);
            }
            dog1.GetComponent<NavMeshAgent>().SetDestination(dogsPosition.transform.position);
            dog1.GetComponent<CastleGuardDogs>().enabled = false;
            dog1.GetComponent<NavMeshAgent>().speed = 5;
            dog1.GetComponent<Animator>().SetFloat("Move Speed", 5f);
            
            if (dog2.GetComponent<Animator>().GetBool("Eating"))
            {
                dog2.GetComponent<Animator>().SetBool("Eating", false);
            }
            dog2.GetComponent<NavMeshAgent>().SetDestination(dogsPosition.transform.position);
            dog2.GetComponent<CastleGuardDogs>().enabled = false;
            dog2.GetComponent<NavMeshAgent>().speed = 5.2f;
            dog2.GetComponent<Animator>().SetFloat("Move Speed", 5.2f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Animal"))
        {
            dog1.GetComponent<Animator>().SetBool("Barking", false);
            dog1.GetComponent<CastleGuardDogs>().enabled = true;
            dog1.GetComponent<NavMeshAgent>().speed = Random.Range(0.85f, 1.05f);
            dog1.GetComponent<NavMeshAgent>().SetDestination(position1.transform.position);

            dog2.GetComponent<Animator>().SetBool("Barking", false);
            dog2.GetComponent<CastleGuardDogs>().enabled = true;
            dog2.GetComponent<NavMeshAgent>().speed = Random.Range(0.85f, 1.05f);
            dog2.GetComponent<NavMeshAgent>().SetDestination(position2.transform.position); 
        }
    }
}
