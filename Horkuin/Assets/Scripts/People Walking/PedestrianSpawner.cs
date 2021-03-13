using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class PedestrianSpawner : MonoBehaviour
{
    public static PedestrianSpawner current;
    
    public GameObject[] pedestrianPrefabs;
    public int pedestriansToSpawn;

    public float progress;
    public bool isDone;
    private void Awake()
    {
        current = this;
        StartCoroutine(Spawn());
    }

    private void Start()
    {
    }

    IEnumerator Spawn()
    {
        int totalcount = 0;
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
    
                progress = (float)totalcount / (float)pedestriansToSpawn;
                
                count++;
                totalcount++;
            }
        }
        yield return new WaitForSeconds(2f);
        isDone = true;
    }
}
