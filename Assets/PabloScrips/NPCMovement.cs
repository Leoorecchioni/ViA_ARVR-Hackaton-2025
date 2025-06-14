using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] Transform destination;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("nav mesh agent component not attached");
        } else
        {
            navMeshAgent.updateRotation = false; //can delete that to add fun when an NPC is moving
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Debug.Log("Im moving");
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
}