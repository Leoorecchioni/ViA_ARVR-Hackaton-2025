using UnityEngine;

public class PrincipalTriggerHandler : MonoBehaviour
{
    // Optional: Assign objects to enable when triggered
    public GameObject childPleadsObject;
    public GameObject teacherCallObject;

    public string currentTrigger = "";

    void OnTriggerEnter(Collider other) {
        string triggerName = other.gameObject.name;

        if (currentTrigger != triggerName) {
            if (triggerName == "child_pleade_trigger") {
                Debug.Log("Principal entered child plea zone.");
                if (childPleadsObject != null)
                    childPleadsObject.SetActive(true);
            }
            else if (triggerName == "teacher_call_trigger") {
                Debug.Log("Principal entered teacher call zone.");
                if (teacherCallObject != null)
                    teacherCallObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other) {
    }
}
