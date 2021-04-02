using UnityEngine;

public class FreeLookChange : MonoBehaviour
{
    public GameObject[] characterStuff;
    public GameObject freelook;
    bool character = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) { // Με το K ενεργοιποιείται η free look κάμερα
            if (character) {
                character = false;
                freelook.SetActive(true);
                foreach (GameObject stuff in characterStuff){
                    stuff.SetActive(false);
                } 
            }
            else {
                character = true;
                foreach (GameObject stuff in characterStuff){
                    stuff.SetActive(true);
                }
                freelook.SetActive(false); 
            }
        }
    }
}
