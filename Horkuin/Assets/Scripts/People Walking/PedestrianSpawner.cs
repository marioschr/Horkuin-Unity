using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject[] pedestrianPrefab;
    public int pedestriansToSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < pedestriansToSpawn)
        {
            GameObject obj = Instantiate(pedestrianPrefab[Random.Range(0,pedestrianPrefab.Length)]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            obj.GetComponent<NavMeshAgent>().enabled = false;
            obj.GetComponent<NavMeshAgent>().enabled = true;
            
            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
