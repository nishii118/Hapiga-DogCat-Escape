using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWireCollider : MonoBehaviour
{
    public static event Action OnCollisionEnterLaser;
    public static event Action OnPlayerBeElectrized;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Player player = other.GetComponent<Player>();
            // StartCoroutine
            OnCollisionEnterLaser?.Invoke();
            Debug.Log("Player entered laser area");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            OnPlayerBeElectrized?.Invoke();
            // OnCollisionEnterLaser?.Invoke();
            Debug.Log("Player entered laser area");

            StartCoroutine(PlayPlayerElectrizedAnimation(player));
        }
    }

    IEnumerator PlayPlayerElectrizedAnimation(Player player)
    {
        player.PlayElectrizedAnimation();
        Debug.Log("PlayPlayerElectrizedAnimation");
        yield return new WaitForSeconds(1f);
        // player.StopPlayerMovement();
        // OnElectrized?.Invoke();
        OnCollisionEnterLaser?.Invoke();

    }
}
