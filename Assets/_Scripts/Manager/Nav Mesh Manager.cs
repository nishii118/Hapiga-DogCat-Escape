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
        Level.OnLevelBeLoaded += UpdateNavMesh;
        Electricity.OnPoliceBeElectrized += UpdateNavMesh;
    }

    void OnDisable()
    {
        Level.OnLevelBeLoaded -= UpdateNavMesh;
        Electricity.OnPoliceBeElectrized -= UpdateNavMesh;
    }

    void UpdateNavMesh() {
        Debug.Log("Update NavMesh");
        navMeshSurface.BuildNavMesh();
    }
}
