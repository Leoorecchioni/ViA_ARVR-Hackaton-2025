using UnityEngine;

public class PrincipalTriggerHandler : MonoBehaviour
{
    public GameObject principalObj;
    public GameObject childPleading;

    public string currentTrigger = "";

    void OnTriggerEnter(Collider other) {
        string triggerName = other.gameObject.name;

        if (currentTrigger != triggerName) {
            if (triggerName == "PhoneZone") {
                Debug.Log("Principal entered phone zone.");
                childPleading.SetActive(true);
                principalObj.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other) {
    }
}
