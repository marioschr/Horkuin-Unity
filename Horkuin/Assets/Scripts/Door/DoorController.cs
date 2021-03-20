using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    public GameObject UIOpenDoor;
    private bool doorMoving = false, doorIsOpen = false;
    private static readonly int Close = Animator.StringToHash("Close");
    private static readonly int Open = Animator.StringToHash("Open");


    private void OnTriggerEnter(Collider other)
    {
        UIOpenDoor.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UIOpenDoor.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !doorMoving)
        {
            if (doorIsOpen)
            {
                animator.SetTrigger(Close);
                doorMoving = true;
                doorIsOpen = false;
                Invoke(nameof(DoorMoving),2.2f);
            }
            else
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
