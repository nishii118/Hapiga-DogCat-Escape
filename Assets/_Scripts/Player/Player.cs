
using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerEnterSuccessSpot;
    public static event Action<Transform> OnPlayerBeSpawned;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator playerAnim;
    void OnEnable()
    {
        CatFood.catFoodEaten += PlayerScaleUp;

        OnPlayerBeSpawned?.Invoke(transform);
    }

    void OnDisable()
    {
        CatFood.catFoodEaten -= PlayerScaleUp;
    }

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        if (JoystickMove.Instance != null)
        {
            JoystickMove.Instance.SetRigidbody(rb);
            JoystickMove.Instance.SetPlayerAnim(playerAnim);
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SuccessSpot"))
        {
            
            OnPlayerEnterSuccessSpot?.Invoke();
        }
    }

    void PlayerScaleUp()
    {
        StartCoroutine(ScaleUpOverTime(new Vector3(1.2f, 1.2f, 1.2f), 0.5f));
    }

    private IEnumerator ScaleUpOverTime(Vector3 targetScale, float duration)
    {
        Vector3 originalScale = transform.localScale;
        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= duration);

        transform.localScale = targetScale;
    }


    public void PlayElectrizedAnimation() {
        playerAnim.CrossFade("Electrized", 0.1f);
    }



}
