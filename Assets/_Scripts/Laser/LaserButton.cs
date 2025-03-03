using System;

using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public static event Action onClickLaserButton;

    [SerializeField] private GameObject objectButtonOn;
    [SerializeField]private bool buttonState = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Police"))
        {
            buttonState = !buttonState;
            objectButtonOn.SetActive(buttonState);
            onClickLaserButton?.Invoke();
        }
        
    }
}
