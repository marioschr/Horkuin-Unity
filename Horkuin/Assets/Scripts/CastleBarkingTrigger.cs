using UnityEngine;
using UnityEngine.AI;

public class CastleBarkingTrigger : MonoBehaviour
{
    public GameObject dogsPosition, dog1, dog2;
    public Transform position1, position2;
    private static readonly int Eating = Animator.StringToHash("Eating");
    private static readonly int MoveSpeed = Animator.StringToHash("Move Speed");

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Animal")) // Όταν ο παίχτης πλησιάσει την πύλη
        {
            if (dog1.GetComponent<Animator>().GetBool(Eating)) // Αν τα σκυλιά τρώνε θα σταματήσουν
                                                               // και τα τρέξουν προς την πύλη
            {
                dog1.GetComponent<Animator>().SetBool(Eating, false);
            }
            dog1.GetComponent<NavMeshAgent>().SetDestination(dogsPosition.transform.position);
            dog1.GetComponent<CastleGuardDogs>().enabled = false;
            dog1.GetComponent<NavMeshAgent>().speed = 5;
            dog1.GetComponent<Animator>().SetFloat(MoveSpeed, 5f);
            
            if (dog2.GetComponent<Animator>().GetBool(Eating))
            {
                dog2.GetComponent<Animator>().SetBool(Eating, false);
            }
            dog2.GetComponent<NavMeshAgent>().SetDestination(dogsPosition.transform.position);
            dog2.GetComponent<CastleGuardDogs>().enabled = false;
            dog2.GetComponent<NavMeshAgent>().speed = 5.2f;
            dog2.GetComponent<Animator>().SetFloat(MoveSpeed, 5.2f);

        }
    }

    private void OnTriggerExit(Collider other) // Αν ο παίχτης απομακρυνθεί τα σκυλιά συνεχίζουν την περιπολία τους 
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
