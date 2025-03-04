using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static event Action OnLevelBeLoaded;
    [SerializeField] private bool haveNavMesh = false;
    // [SerializeField] NavMeshSurface navMeshSurface;

    void OnEnable()
    {
        // if (haveNavMesh == true) {
        //     Debug.Log("NavMesh is enabled");
        //     OnLevelBeLoaded?.Invoke();
        // }
    }

    void Start()
    {
        if (haveNavMesh == true) {
            Debug.Log("NavMesh is enabled");
            OnLevelBeLoaded?.Invoke();
        }
        
    }
}
