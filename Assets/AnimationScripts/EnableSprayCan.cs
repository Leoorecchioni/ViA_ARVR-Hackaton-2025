using UnityEngine;


public class EnableSprayAfterAudio : MonoBehaviour
{
    public AudioSource childPleadingAudio;
    public GameObject sprayCan;
    public Material yellowMaterial;

    public GameObject childPleading;

    private bool audioStarted = false;
    private bool hasActivated = false;

    void Update()
    {
        if (!hasActivated)
        {
            // Check if the audio has started playing
            if (childPleadingAudio.isPlaying)
            {
                audioStarted = true;
            }

            // If the audio has played and then stopped, activate
            if (audioStarted && !childPleadingAudio.isPlaying)
            {
                ActivateSprayCan();
                hasActivated = true;
            }
        }
    }

    void ActivateSprayCan()
    {
        if (sprayCan == null)
        {
            Debug.LogWarning("Spray Can object not assigned.");
            return;
        }

        // Enable XR Grab Interactable
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = sprayCan.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null)
        {
            grab.enabled = true;
        }
        else
        {
            Debug.LogWarning("XRGrabInteractable not found on Spray Can.");
        }

        // Change first material to yellow
        MeshRenderer meshRenderer = sprayCan.GetComponent<MeshRenderer>();
        if (meshRenderer != null && yellowMaterial != null)
        {
            Material[] mats = meshRenderer.materials;
            mats[0] = yellowMaterial;
            meshRenderer.materials = mats;
        }
        else
        {
            Debug.LogWarning("MeshRenderer or yellow material not assigned.");
        }

        Debug.Log("Spray can activated and changed to yellow.");
        childPleading.SetActive(false);
    }
}
