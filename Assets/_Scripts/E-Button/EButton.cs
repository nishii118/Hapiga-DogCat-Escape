using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EButton : MonoBehaviour
{
    [SerializeField] GameObject onButtonObject;
    // Start is called before the first frame update
    private bool objectState = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered E Button area");
            objectState = !objectState;
            onButtonObject.SetActive(objectState);

            Messenger.Broadcast(EventKey.TURN_ON_ELECTRICITY);            
        }
    }
}
