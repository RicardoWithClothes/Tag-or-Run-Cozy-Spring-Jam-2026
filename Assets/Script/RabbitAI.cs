using UnityEngine;
using UnityEngine.AI;


public class RabbitAI : MonoBehaviour
{

    [Header("Targeting")]
    public Transform player;
    private NavMeshAgent agent;

    [Header("Speed Settings")]
    public float normalSpeed = 3.5f;  
    public float nightmareSpeed = 8f;
    private PillBar realityBar;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        realityBar = FindObjectOfType<PillBar>();


        if (player == null) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null) {
                player = playerObject.transform;
            }
        }
    }
    void Update()
    {
        if (player != null) {
            agent.SetDestination(player.position);
        }
        if (realityBar != null && agent != null) {
            agent.speed = Mathf.Lerp(nightmareSpeed, normalSpeed, realityBar.fillAmount);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("GAME OVER: You were tagged!");
            FindObjectOfType<GameManager>().TriggerGameOver();
        }
    }
}
