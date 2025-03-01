using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public static event Action onClickLaserButton;

    [SerializeField] private GameObject objectButtonOn;
    private bool buttonState = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonState = !buttonState;
            objectButtonOn.SetActive(buttonState);
            onClickLaserButton?.Invoke();
        }
    }
}
