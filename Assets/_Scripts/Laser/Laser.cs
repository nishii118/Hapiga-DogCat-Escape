using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static event Action onCollisionEnterLaser;
    [SerializeField] private GameObject laserActivatableObject;


    void OnEnable()
    {
        LaserButton.onClickLaserButton+= TurnOnLaser;
    }

    void OnDisable()
    {
        LaserButton.onClickLaserButton-= TurnOnLaser;
    }
    

    void TurnOnLaser() {
        laserActivatableObject.SetActive(!laserActivatableObject.activeSelf);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered laser area");
            onCollisionEnterLaser?.Invoke();
        }
    }
}
