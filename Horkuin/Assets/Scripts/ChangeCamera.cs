using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera firstPerson;
    public GameObject character, head;

    private bool thirdP = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (thirdP)
            {
                firstPerson.Priority = 21;
	            Invoke("DisableBody", 0.35f);
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
