using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWall : MonoBehaviour
{
    [SerializeField] BoxCollider shieldCollider;

    void OnEnable()
    {
        Messenger.AddListener(EventKey.UNSHIELD_WALL, UnShieldWall);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.UNSHIELD_WALL, UnShieldWall);
    }

    void UnShieldWall()
    {
        shieldCollider.enabled = false;
    }
}
