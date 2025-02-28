using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWall : MonoBehaviour
{
    [SerializeField] BoxCollider shieldCollider;

    void OnEnable()
    {
        CatFood.catFoodEaten+= UnShieldWall;
        // Messenger.AddListener(EventKey.UNSHIELD_WALL, UnShieldWall);
    }

    void OnDisable()
    {
        CatFood.catFoodEaten-= UnShieldWall;
        // Messenger.RemoveListener(EventKey.UNSHIELD_WALL, UnShieldWall);
    }

    void UnShieldWall()
    {
        shieldCollider.enabled = false;
    }
}
