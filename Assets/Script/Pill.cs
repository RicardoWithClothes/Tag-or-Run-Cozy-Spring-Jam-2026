using UnityEngine;

public class Pill : MonoBehaviour {


    [Header("Glow Settings")]
    public Light glowLight; 
    public float minIntensity = 1f;
    public float maxIntensity = 3f;
    public float pulseSpeed = 2f;



    private void OnTriggerEnter(Collider other) {
        PillBar pill = FindObjectOfType<PillBar>();
        if (pill != null && other.CompareTag("Player")) {
            pill.FillBar();
            // Destroy(gameObject);
        }
    }
    private void Update() { 
    
        transform.Rotate(Vector3.up * 50f * Time.deltaTime);
        transform.Rotate(Vector3.right * 30f * Time.deltaTime);
        if (glowLight != null) {
            float pulse = Mathf.Sin(Time.time * pulseSpeed);
            float currentIntensity = Mathf.Lerp(minIntensity, maxIntensity, (pulse + 1f) / 2f);
            glowLight.intensity = currentIntensity;
        }
    }
}