using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static event Action OnLevelBeLoaded; // build navmesh
    public static event Action OnLevelBeLoaded2; // active player's movement
    [SerializeField] private bool haveNavMesh = false;
    // [SerializeField] NavMeshSurface navMeshSurface;

    void OnEnable()
    {
        // if (haveNavMesh == true) {
        //     Debug.Log("NavMesh is enabled");
        //     OnLevelBeLoaded?.Invoke();
        // }
        Debug.Log("Level loaded");
        OnLevelBeLoaded2?.Invoke();
    }

    void Start()
    {
        if (haveNavMesh == true)
        {
            // Debug.Log("NavMesh is enabled");
            OnLevelBeLoaded?.Invoke();

            Debug.Log("Level loaded");
        }

    }
}
