using UnityEngine;
using UnityEngine.UI;


public class PillBar : MonoBehaviour
{
    public Image fill;
    public float drainRate = 0.05f; // Amount lost per second

    public float fillAmount { get; set; } = 1.0f; 

    private void Update() {
        fillAmount = Mathf.Clamp01(fillAmount - drainRate * Time.deltaTime);
        fill.fillAmount = fillAmount;

    }
    public void FillBar() {
        fillAmount = 1.0f;
    }
}
