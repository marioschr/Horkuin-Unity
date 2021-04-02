using System.Collections;
using UnityEngine;
using UnityEngine.AI;
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

    IEnumerator Spawn()
    {
        int totalcount = 0;
        Transform parentObject = GameObject.FindGameObjectWithTag("Spawns").transform;
        foreach(GameObject prefab in pedestrianPrefabs) { // Ξεκινάει ένα loop που δημιουργεί χαρακτήρες ανάλογα τον αριθμό που δήλώσαμε
            int count = 0;
            while (count < pedestriansToSpawn / pedestrianPrefabs.Length)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + new Vector3(0,100,0), -transform.up, out hit))
                {
                    var slopeRotation = Quaternion.FromToRotation(transform.up, hit.normal);
                    transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
                }
                Transform child = transform.GetChild(Random.Range(0, transform.childCount)); // Πέρνει τυχαία κάποιο από τα waypoints
                GameObject obj = Instantiate(prefab, child.position, child.rotation, parentObject);  // Τοποθετείται στο έδαφος στο σημείο αυτό
                obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();	
                yield return new WaitForEndOfFrame();
                progress = (float)totalcount / pedestriansToSpawn; // Το προσθέτουμε στο loading bar
                count++;
                totalcount++;
            }
        }
        yield return new WaitForSeconds(2f);
        isDone = true;
    }
}
