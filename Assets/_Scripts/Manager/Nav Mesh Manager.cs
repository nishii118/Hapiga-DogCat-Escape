using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField] NavMeshSurface navMeshSurface;
    void OnEnable()
    {
        Level.onLevelBeLoaded += UpdateNavMesh;
        Electricity.onPoliceBeElectrized += UpdateNavMesh;
    }

    void OnDisable()
    {
        Level.onLevelBeLoaded -= UpdateNavMesh;
        Electricity.onPoliceBeElectrized -= UpdateNavMesh;
    }

    void UpdateNavMesh() {
        navMeshSurface.BuildNavMesh();
    }
}
