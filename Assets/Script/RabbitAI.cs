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

    public Light[] eyes;

    [Header("Audio Settings")]
    public AudioSource rabbitSound;

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

            float inverseFill = 1f - realityBar.fillAmount;
            foreach (Light eye in eyes) {
                if (eye != null) {
                    eye.color = Color.Lerp(Color.white, Color.red, inverseFill);
                    eye.intensity = Mathf.Lerp(0f, 10f, inverseFill);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("GAME OVER: You were tagged!");
            FindObjectOfType<GameManager>().TriggerGameOver();
        }
    }
}
