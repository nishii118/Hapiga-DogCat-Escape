using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public static event Action OnElectrized;
    public static event Action OnPoliceBeElectrized;
    public static event Action OnPlayerBeElectrized;
    [SerializeField] private GameObject electricityActivatableObject;
    [SerializeField] private BoxCollider electricityCollider;

    private bool electricityState = false;
    void Start()
    {
        electricityCollider.enabled = electricityState;
    }
    void OnEnable()
    {
        EButton.onClickEButton+= TurnOnElectricity;
        // Messenger.AddListener(EventKey.TURN_ON_ELECTRICITY, TurnOnElectricity);
    }

    void OnDisable()
    {
        EButton.onClickEButton-= TurnOnElectricity;
        // Messenger.RemoveListener(EventKey.TURN_ON_ELECTRICITY, TurnOnElectricity);
    }
    

    private void TurnOnElectricity() {
        Debug.Log("TurnOnElectricity");
        electricityState = !electricityState;
        electricityCollider.enabled = electricityState;
        electricityActivatableObject.SetActive(electricityState);
    }

    void OnTriggerEnter(Collider other)
    { 
        Debug.Log("electricityState: " + electricityState);
        if (electricityState == false) return;
        if (other.CompareTag("Police"))
        {
            Debug.Log("Police entered electricity area");
            // Messenger.Broadcast(EventKey.TURN_ON_ELECTRICITY);
            // Animator policeAnimator = other.GetComponent<Animator>();
            // policeAnimator.CrossFade("Electrized", 0.1f);  

            Police police = other.GetComponent<Police>();
            police.PlayElectrizedAnimation();
            police.StopPoliceMovement();
            OnPoliceBeElectrized?.Invoke();

        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered electricity area");
            Player player = other.GetComponent<Player>();
            Debug.Log("Player: " + player);

            OnPlayerBeElectrized?.Invoke();
            StartCoroutine(PlayPlayerElectrizedAnimation(player));
            // Messenger.Broadcast(EventKey.TURN_ON_ELECTRICITY);

        }

        IEnumerator PlayPlayerElectrizedAnimation(Player player)
        {
            player.PlayElectrizedAnimation();
            Debug.Log("PlayPlayerElectrizedAnimation");
            yield return new WaitForSeconds(1f);
            // player.StopPlayerMovement();
            OnElectrized?.Invoke();

        }

    }
}
