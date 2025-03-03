using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    [SerializeField] private Follower follower;
    [SerializeField] private Animator cageAnimator;
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
        // Debug.Log("ST entered cage");
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered cage"); 
            StartCoroutine(PlayUnlockCageAnimation());
            // other.GetComponent<Follower>().isCaged = true;
            follower.SetIsCaged(false);
        }
    }

    IEnumerator PlayUnlockCageAnimation()
    {
        cageAnimator.CrossFade("Unlock", 0.1f);
        yield return null;
        // GetComponent<Animator>().SetTrigger("Close");
    }
}
