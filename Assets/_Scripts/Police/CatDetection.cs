using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatDetection : MonoBehaviour
{
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
            // animator.SetBool("detected", true);
            // Time.timeScale = 0f;
            StartCoroutine(DetectDog());
            // GameManager.Instance.ReloadCurrentScene();
            // LevelManager.Instance.LoadCurrentLevel();
            Messenger.Broadcast(EventKey.LOAD_CURRENT_LEVEL);
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
