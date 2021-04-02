using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera firstPerson;
    public GameObject character, head;

    private bool thirdP = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) // Όταν ο χρήστης πατήσει V αλλάζει camera
        {
            if (thirdP)
            {
                firstPerson.Priority = 21; // Αλλάζοντας την πρωτεραιότητα αλλάζει και το ποια κάμερα θα δέιχνει
	            Invoke(nameof(DisableBody), 0.35f); // Κρύβουμε το σώμα του παίχτη για να μην εμποδίζει την κάμερα σε πρώτο πρόσωπο
                thirdP = false;
		        head.SetActive(true);
            }
            else
            {
                firstPerson.Priority = 19;
                thirdP = true;
		        character.SetActive(true);
            }
        }
    }

    void DisableBody() {
	     character.SetActive(false);
    }
}
