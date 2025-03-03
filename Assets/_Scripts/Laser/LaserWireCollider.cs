using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWireCollider : MonoBehaviour
{
    public static event Action onCollisionEnterLaser;
   void OnCollisionEnter(Collision other)
   {
    if(other.gameObject.CompareTag("Player"))
    {
        onCollisionEnterLaser?.Invoke();
        Debug.Log("Player entered laser area");
    }
   }
}
