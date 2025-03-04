using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenArea : MonoBehaviour
{
    public static event Action onOpenDoor;
    [SerializeField] private Animator doorAnimator;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered door open area");
            // doorAnimator.SetBool("Open", true);
            doorAnimator.CrossFade("Opened", 0.1f);
            onOpenDoor?.Invoke();
            // Messenger.Broadcast(EventKey.CABINET_DOOR_OPEN);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited door open area");
            // doorAnimator.SetBool("Open", false);
            doorAnimator.CrossFade("Closed", 0.1f);
        }
    }
}


// trigger enter open door 
// trigger exit close door