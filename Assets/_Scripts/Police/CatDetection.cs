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
        Messenger.AddListener(EventKey.SAFE_AREA_ENTER, OnSafeAreaEnter);
        Messenger.AddListener(EventKey.SAFE_AREA_EXIT, OnSafeAreaExit);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.SAFE_AREA_ENTER, OnSafeAreaEnter);
        Messenger.RemoveListener(EventKey.SAFE_AREA_EXIT, OnSafeAreaExit);
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
        if (other.gameObject.CompareTag("Player"))
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
