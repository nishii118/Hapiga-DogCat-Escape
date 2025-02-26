using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{
    [SerializeField] private Animator catFoodAnimator;
    // Start is called before the first frame update
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
            Debug.Log("Player entered cat food area");
            StartCoroutine(PlayEatenAnimation());
            gameObject.SetActive(false);
            Messenger.Broadcast(EventKey.UNSHIELD_WALL);
            Messenger.Broadcast(EventKey.PLAYER_SCALE_UP);
        }
    }

    IEnumerator PlayEatenAnimation()
    {
        catFoodAnimator.CrossFade("EatIt", 0.1f);
        yield return null;
    }
}
