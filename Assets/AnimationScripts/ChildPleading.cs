using UnityEngine;

public class FloatAndSway : MonoBehaviour
{
    public Transform childPosition; // Reference to your character

    public float floatAmplitude = 0.5f;   // Height of the bobbing motion
    public float floatFrequency = 1f;     // Speed of the bobbing motion

    public float swayAngle = 30f;         // Max angle for side-to-side sway
    public float swayFrequency = 0.5f;    // How fast it sways left/right

    public float flipDuration = 1f;       // Time for a backflip
    public float flipInterval = 10f;      // Time between backflips

    private Vector3 startPosition;
    private float timeSinceLastFlip = 0f;
    private bool isFlipping = false;
    private float flipTimeElapsed = 0f;
    private Quaternion initialRotation;
    private Quaternion targetFlipRotation;

    void Start()
    {
        if (childPosition == null)
        {
            Debug.LogError("ChildPosition not assigned.");
            enabled = false;
            return;
        }

        startPosition = childPosition.position;
    }

    void Update()
    {
        float time = Time.time;

        // Bobbing motion
        float yOffset = Mathf.Sin(time * floatFrequency * 2 * Mathf.PI) * floatAmplitude;
        yOffset = yOffset * yOffset / 2;
        childPosition.position = startPosition + Vector3.up * yOffset;

        // Y-axis sway rotation: oscillate between -swayAngle and +swayAngle
        float sway = Mathf.Sin(time * swayFrequency * 2 * Mathf.PI) * swayAngle;
        Quaternion swayRotation = Quaternion.Euler(0f, sway, 0f);

        if (!isFlipping)
        {
            childPosition.rotation = swayRotation;
        }

        // Backflip logic
        timeSinceLastFlip += Time.deltaTime;

        if (!isFlipping && timeSinceLastFlip >= flipInterval)
        {
            StartFlip();
        }

        if (isFlipping)
        {
            flipTimeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(flipTimeElapsed / flipDuration);
            childPosition.rotation = Quaternion.Slerp(initialRotation, targetFlipRotation, t);

            if (t >= 1f)
                EndFlip();
        }
    }

    void StartFlip()
    {
        isFlipping = true;
        timeSinceLastFlip = 0f;
        flipTimeElapsed = 0f;

        initialRotation = childPosition.rotation;
        targetFlipRotation = initialRotation * Quaternion.Euler(360f, 0f, 0f); // 360° flip on X-axis
    }

    void EndFlip()
    {
        isFlipping = false;

        // Reset rotation to resume swaying cleanly
        float time = Time.time;
        float sway = Mathf.Sin(time * swayFrequency * 2 * Mathf.PI) * swayAngle;
        childPosition.rotation = Quaternion.Euler(0f, sway, 0f);
    }
}
