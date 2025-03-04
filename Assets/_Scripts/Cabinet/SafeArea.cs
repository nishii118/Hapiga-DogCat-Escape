using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public static event Action onSafeAreaEnter; 
    public static event Action onSafeAreaExit;  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered safe area");
            // Messenger.Broadcast(EventKey.SAFE_AREA_ENTER);
            onSafeAreaEnter?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited safe area");
            onSafeAreaExit?.Invoke();
            // Messenger.Broadcast(EventKey.SAFE_AREA_EXIT);
        }
    }
}
