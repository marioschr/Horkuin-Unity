using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject[] pedestrianPrefabs;
    public int pedestriansToSpawn;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        foreach(GameObject prefab in pedestrianPrefabs) {
            int count = 0;
            while (count < Mathf.RoundToInt(pedestriansToSpawn / pedestrianPrefabs.Length))
            {
                GameObject obj = Instantiate(prefab);
                Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
                obj.transform.position = child.position;
                obj.GetComponent<NavMeshAgent>().enabled = false;
                obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
                obj.GetComponent<NavMeshAgent>().enabled = true;

                yield return new WaitForEndOfFrame();
    
                count++;
            }
        }
    }
}
