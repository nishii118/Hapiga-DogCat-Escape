using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDetection : MonoBehaviour
{
    [SerializeField] private Animator animator;
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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            animator.SetBool("detected", true);

            StartCoroutine(DetectDog());
        }
    }

    IEnumerator DetectDog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Dog detected");
    }
}
