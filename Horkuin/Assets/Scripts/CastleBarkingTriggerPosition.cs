using UnityEngine;
using UnityEngine.AI;

public class CastleBarkingTriggerPosition : MonoBehaviour
{
    public GameObject player;
    private static readonly int Barking = Animator.StringToHash("Barking");
    private static readonly int MoveSpeed = Animator.StringToHash("Move Speed");

    private void OnTriggerEnter(Collider other) // Όταν ο παίχτης είναι κοντά στην πύλη και τα σκυλιά φτάσουν και αυτά στην πύλη
    {
        if (other.tag.Equals("Dog")) // Ξεκινάνε να γαβγίζουν και να πηδάνε στα κάγκελα
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            other.GetComponent<NavMeshAgent>().speed = 0;
            other.GetComponent<Transform>().LookAt(new Vector3(player.transform.position.x, other.transform.position.y,
                player.transform.position.z));
            other.GetComponent<Animator>().SetFloat(MoveSpeed, 0f);
            other.GetComponent<Animator>().SetBool(Barking, true);
        }
    }

    private void OnTriggerStay(Collider other) // όσο ο παίχτης είναι κοντά παραμένουν και τα σκυλιά
    {
        if (other.tag.Equals("Dog"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
