using System;
using System.Collections;
using UnityEngine;

public class CatDetection : MonoBehaviour
{
    public static event Action onDetectCat;
    [SerializeField] private Animator animator;
    private bool canDetect = true;

    void OnEnable()
    {
        SafeArea.onSafeAreaEnter += OnSafeAreaEnter;
        SafeArea.onSafeAreaExit += OnSafeAreaExit;
    }

    void OnDisable()
    {
        SafeArea.onSafeAreaEnter -= OnSafeAreaEnter;
        SafeArea.onSafeAreaExit -= OnSafeAreaExit;  
    }
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
        
        if (other.gameObject.CompareTag("Player") && canDetect)
        {
            Debug.Log("Player detected");
          
            StartCoroutine(DetectDog());
          
            onDetectCat?.Invoke();
        }
    }

    IEnumerator DetectDog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Dog detected");
    }

    void OnSafeAreaEnter()
    {
        canDetect = false;
    }

    void OnSafeAreaExit()
    {
        canDetect = true;
    }
}
