using UnityEngine;

public class Pill : MonoBehaviour {

    public Light glowLight;

    private PillBar realityBar;


    void Start() {
        realityBar = FindObjectOfType<PillBar>();
    }
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
        if (glowLight != null && realityBar != null) {
            glowLight.intensity = Mathf.Lerp(15f, 0.1f, realityBar.fillAmount);
        }
    }
}