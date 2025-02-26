using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered safe area");
            Messenger.Broadcast(EventKey.SAFE_AREA_ENTER);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited safe area");
            Messenger.Broadcast(EventKey.SAFE_AREA_EXIT);
        }
    }
}
