using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Time.timeScale = 0f;
            StartCoroutine(DetectDog());
            GameManager.Instance.ReloadCurrentScene();
        }
    }

    IEnumerator DetectDog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Dog detected");
    }
}
