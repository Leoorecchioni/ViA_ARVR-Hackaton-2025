using UnityEngine;

public class SprayCanCollisionTrigger : MonoBehaviour
{
    public GameObject npcHidden;
    public GameObject npcCaughtEvidence;
    public GameObject sprayCan;

    bool hit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hit)
        {
            string targetName = collision.gameObject.name;

            if (targetName == "SprayCanOut")
            {
                Debug.Log("Spray can placed correctly.");
                if (npcHidden != null)
                    npcHidden.SetActive(true);
                hit = true;
            }
            else if (targetName == "SprayCanFail")
            {
                Debug.Log("Spray can placed incorrectly — evidence found.");
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
            }
        }
    }
}
