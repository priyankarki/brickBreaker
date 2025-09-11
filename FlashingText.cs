using UnityEngine;
using TMPro; // only if using TextMeshPro

public class FlashingText : MonoBehaviour
{
    public float flashSpeed = 0.36f; // flashes per second
    private TMP_Text tmpText;

    private void Start()
    {
        tmpText = GetComponent<TMP_Text>(); // TextMeshPro component
        if (tmpText == null)
            Debug.LogWarning("FlashingText script requires a TMP_Text component!");
    }

    private void Update()
    {
        if (tmpText != null)
        {
            float alpha = (Mathf.Sin(Time.time * flashSpeed * Mathf.PI * 2) + 1f) / 2f;
            Color c = tmpText.color;
            c.a = alpha;
            tmpText.color = c;
        }
    }
}
