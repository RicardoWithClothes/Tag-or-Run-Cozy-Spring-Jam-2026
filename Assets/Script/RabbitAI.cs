using UnityEngine;
using UnityEngine.AI;


public class RabbitAI : MonoBehaviour
{

    [Header("Targeting")]
    public Transform player;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("GAME OVER: You were tagged!");
            FindObjectOfType<GameManager>().TriggerGameOver();
        }
    }
}
