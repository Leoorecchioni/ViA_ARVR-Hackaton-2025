using UnityEngine;

public class SprayCanCollisionTrigger : MonoBehaviour
{
    public GameObject npcHidden;
    public GameObject npcCaughtEvidence;
    public GameObject sprayCan;
    public Material blueMaterial;


    bool hit = false;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YEEEEET.");
        if (hit == false || true)
        {
            string targetName = collision.gameObject.name;
            Debug.Log("YEEEEET.");
            Debug.Log(targetName);

            Debug.Log("SprayCanOut =? " + targetName);
            Debug.Log("Floor =? " + targetName);


            if (targetName == "SprayCanOut")
            {
                Debug.Log("BEEAT.");
                if (npcHidden != null)
                    npcHidden.SetActive(true);
                hit = true;
            }
            else if (targetName == "Floor")
            {
                Debug.Log("SKEAT.");
                if (npcCaughtEvidence != null)
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
            }
        }
    }
}
