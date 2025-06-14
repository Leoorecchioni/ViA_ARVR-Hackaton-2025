using UnityEngine;

public class PrincipalTriggerHandler : MonoBehaviour
{
    // Optional: Assign objects to enable when triggered
    public GameObject phoneAreaObj;
    public GameObject principalObj;

    public string currentTrigger = "";

    void OnTriggerEnter(Collider other) {
        string triggerName = other.gameObject.name;

        if (currentTrigger != triggerName) {
            if (triggerName == "PhoneZone") {
                Debug.Log("Principal entered phone zone.");
                if (phoneAreaObj != null)
                    phoneAreaObj.SetActive(true);
                    principalObj.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other) {
    }
}
