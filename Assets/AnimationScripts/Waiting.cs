using UnityEngine;

public class WaitingForDecision : MonoBehaviour
{
    public AudioSource waitingAudio;
    public GameObject waitingAudioObj;
    public GameObject npcWaiting;
    public GameObject npcHidden;
    public GameObject npcCaughtEvidence;
    public GameObject sprayCan;
    public Material blueMaterial;

    private bool audioStarted = false;
    private bool hasActivated = false;

    void Update()
    {
        if (!hasActivated)
        {
            if (waitingAudio.isPlaying)
            {
                audioStarted = true;
            }
            if (audioStarted && !waitingAudio.isPlaying && gameObject.activeInHierarchy && gameObject.activeSelf)
            {
                if (!npcCaughtEvidence.activeSelf && !npcHidden.activeSelf)
                {
                    npcWaiting.SetActive(true);

                    var grab = sprayCan.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
                    if (grab != null)
                    {
                        grab.enabled = false;
                    }

                    MeshRenderer meshRenderer = sprayCan.GetComponent<MeshRenderer>();
                    if (meshRenderer != null && blueMaterial != null)
                    {
                        Material[] mats = meshRenderer.materials;
                        mats[0] = blueMaterial;
                        meshRenderer.materials = mats;
                    }

                    SprayCanCollisionTrigger collisionScript = sprayCan.GetComponent<SprayCanCollisionTrigger>();
                    if (collisionScript != null)
                    {
                        collisionScript.enabled = false;
                    }
                }
                hasActivated = true;
            }
        }
    }
}
