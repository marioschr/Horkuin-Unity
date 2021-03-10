using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CastleBarkingTriggerPosition : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Dog"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            other.GetComponent<NavMeshAgent>().speed = 0;
            other.GetComponent<Transform>().LookAt(new Vector3(player.transform.position.x, other.transform.position.y,
                player.transform.position.z));
            other.GetComponent<Animator>().SetFloat("Move Speed", 0f);
            other.GetComponent<Animator>().SetBool("Barking", true);
        }
    }

    private void OnTriggerStay(Collider other)
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
