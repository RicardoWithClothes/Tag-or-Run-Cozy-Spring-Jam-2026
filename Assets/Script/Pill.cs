using UnityEngine;

public class Pill : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        PillBar pill = FindObjectOfType<PillBar>();
        if (pill != null && other.CompareTag("Player")) {
            pill.FillBar();
            // Destroy(gameObject);
        }
    }
}