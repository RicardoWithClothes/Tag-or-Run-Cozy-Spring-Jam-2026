using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PillBar : MonoBehaviour
{
    [Header("UI & Logic")]
    public Image fill;
    public float drainRate = 0.05f;
    public float fillAmount { get; set; } = 1.0f;
    public AudioSource coinCollectSound;

    [Header("Post Processing")]
    public Volume nightmareVolume;

    private void Update() {
        fillAmount = Mathf.Clamp01(fillAmount - drainRate * Time.deltaTime);
        fill.fillAmount = fillAmount;
        if (nightmareVolume != null) {
            nightmareVolume.weight = 1f - fillAmount;
        }

    }
    public void FillBar() {
        fillAmount = 1.0f;
        coinCollectSound.Play();
    }
}
