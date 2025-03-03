using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static event Action onLevelBeLoaded;
    [SerializeField] private bool haveNavMesh = false;
    // [SerializeField] NavMeshSurface navMeshSurface;

    void OnEnable()
    {
        if (haveNavMesh == true) {
            onLevelBeLoaded?.Invoke();
        }
    }
}
