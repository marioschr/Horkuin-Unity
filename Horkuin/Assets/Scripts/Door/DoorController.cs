using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    public GameObject UIOpenDoor;
    private bool doorMoving = false, doorIsOpen = false;
    private static readonly int Close = Animator.StringToHash("Close");
    private static readonly int Open = Animator.StringToHash("Open");


    private void OnTriggerEnter(Collider other) // Όταν ο παίχτης μπει στην περιοχή κοντά στην πόρτα
    {
        UIOpenDoor.SetActive(true); // Εμφανίζεται το μήνυμα
    }

    private void OnTriggerExit(Collider other) // Όταν απομακρυνθεί από την πόρτα
    {
        UIOpenDoor.SetActive(false); // Απενεργοποιείται το μήνυμα
    }

    private void OnTriggerStay(Collider other) // Όσο είναι κοντά στην πόρτα
    {
        if (Input.GetKeyDown(KeyCode.E) && !doorMoving) // Αν πατήσει το Ε και η πόρτα δεν είναι σε κίνηση
        {
            if (doorIsOpen) // Αν είναι ανοιχτή την κλείνει
            {
                animator.SetTrigger(Close); 
                doorMoving = true;
                doorIsOpen = false;
                Invoke(nameof(DoorMoving),2.2f);
            }
            else // Αν είναι κλειστή την ανοίγει
            {
                animator.SetTrigger(Open);
                doorMoving = true;
                doorIsOpen = true;
                Invoke(nameof(DoorMoving),2.2f);
            }
        }
    }

    void DoorMoving()
    {
        doorMoving = false;
    }
}
