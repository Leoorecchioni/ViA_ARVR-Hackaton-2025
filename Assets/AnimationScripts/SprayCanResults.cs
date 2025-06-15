using UnityEngine;

public class SprayCanCollisionTrigger : MonoBehaviour
{
    public GameObject npcWaiting;
    public GameObject npcHidden;
    public GameObject npcCaughtEvidence;
    public GameObject sprayCan;
    public Material blueMaterial;

    public GameObject waitingAudio;

    bool hit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (hit == false)
        {
            string targetName = collision.gameObject.name;
            if (targetName == "SprayCanOut" || targetName == "SprayCanOutL" || targetName == "SprayCanOutR")
            {
                if (npcHidden != null && !npcCaughtEvidence.activeSelf && !npcWaiting.activeSelf)
                    npcHidden.SetActive(true);
                hit = true;
            }
            else if (targetName == "Floor")
            {
                if (npcCaughtEvidence != null && !npcWaiting.activeSelf && !npcHidden.activeSelf)
                    npcCaughtEvidence.SetActive(true);
                hit = true;
            }
            if (hit == true)
            {
                UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = sprayCan.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
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
                waitingAudio.SetActive(false);
            }
        }
    }
}
