
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool isCaged = true;
    [SerializeField] private Animator animator;
    void OnEnable()
    {
        Player.OnPlayerBeSpawned += SetPlayer;
    }

    void OnDisable()
    {
        Player.OnPlayerBeSpawned -= SetPlayer;
    }
    void Start()
    {
        agent.speed = 4.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCaged)
        {
            agent.destination = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 0.1f);
            animator.SetFloat("IdleRunSpeed", agent.velocity.magnitude);
        }
    }

    void SetPlayer(Transform playerTransform)
    {
        player = playerTransform.gameObject;
    }

    public void SetIsCaged(bool value)
    {
        isCaged = value;
    }
}
