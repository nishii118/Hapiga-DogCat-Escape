using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    [SerializeField] private GameObject electricityActivatableObject;

    private bool electricityState = false;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TurnOnElectricity() {
        electricityState = !electricityState;
        electricityActivatableObject.SetActive(electricityState);
    }

    void OnTriggerEnter(Collider other)
    { 
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
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered electricity area");
            // Messenger.Broadcast(EventKey.TURN_ON_ELECTRICITY);

        }
    }
}
