
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    void OnEnable()
    {
        Messenger.AddListener(EventKey.PLAYER_SCALE_UP, PlayerScaleUp);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.PLAYER_SCALE_UP, PlayerScaleUp);
    }

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        if (JoystickMove.Instance != null)
        {
            JoystickMove.Instance.SetRigidbody(GetComponent<Rigidbody>());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SuccessSpot"))
        {
            // GameManager.Instance.LoadNextScene();

            Messenger.Broadcast(EventKey.LOAD_NEXT_LEVEL);
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






}
