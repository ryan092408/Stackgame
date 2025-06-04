using UnityEngine;

public class FadeOutAndDestroy : MonoBehaviour
{
    [SerializeField] private Material fadeMaterial;
    [SerializeField] private float duration = 0.5f;

    private Material runtimeMat;
    private Color startColor;
    private float timer = 0f;
    private float halfDuration;

    void Start()
    {
        // Create an instance of the material so we don’t affect other objects
        runtimeMat = new Material(fadeMaterial);
        GetComponent<Renderer>().material = runtimeMat;

        startColor = runtimeMat.color;
        startColor.a = 0f;
        runtimeMat.color = startColor;

        halfDuration = duration / 2f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float alpha;

        if (timer <= halfDuration)
        {
            // Fade IN (0 → 1)
            alpha = Mathf.Lerp(0f, 1f, timer / halfDuration);
        }
        else
        {
            // Fade OUT (1 → 0)
            float fadeOutTime = timer - halfDuration;
            alpha = Mathf.Lerp(1f, 0f, fadeOutTime / halfDuration);
        }

        runtimeMat.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
