using System;

using UnityEngine;

public class Laser : MonoBehaviour
{
    public static event Action OnCollisionEnterLaser;
    [SerializeField] private GameObject laserActivatableObject;
    
    private bool laserState = true;


    void OnEnable()
    {
        LaserButton.onClickLaserButton+= TurnOnLaser;
    }

    void OnDisable()
    {
        LaserButton.onClickLaserButton-= TurnOnLaser;
    }
    

    void TurnOnLaser() {
        laserState = !laserState;
        Debug.Log("Laser state: " + laserState);
        laserActivatableObject.SetActive(laserState);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("other: " + other.gameObject.name);
    //     if (other.gameObject.CompareTag("Player") && laserState == true)
    //     {
    //         Debug.Log("Player entered laser area");
    //         onCollisionEnterLaser?.Invoke();
    //     }
    // }

    
}
