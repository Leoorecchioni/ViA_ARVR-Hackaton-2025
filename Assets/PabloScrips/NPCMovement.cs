using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class NPCMovement : MonoBehaviour
{
    public List<Transform> destinations; // List of main destinations
    public List<AudioClip> songs; // List of songs to play at each destination
    public float roamRadius = 5f; // Radius within which the NPC can roam around a destination
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private int currentDestinationIndex = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not attached.");
        }
        else if (destinations.Count > 0)
        {
            StartCoroutine(MoveAndPlayAudio());
        }
    }

    IEnumerator MoveAndPlayAudio()
    {
        while (currentDestinationIndex < destinations.Count)
        {
            // Set the destination for the NavMeshAgent
            Vector3 targetDestination = destinations[currentDestinationIndex].position;
            navMeshAgent.SetDestination(targetDestination);

            // Wait until the NPC reaches the vicinity of the destination
            while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                // Occasionally set a new random target within the roam radius
                if (Random.Range(0, 100) < 10) // 10% chance to choose a new random target
                {
                    Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
                    randomDirection += targetDestination;
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas))
                    {
                        navMeshAgent.SetDestination(hit.position);
                    }
                }
                yield return null;
            }

            // Play the corresponding song
            if (audioSource != null && currentDestinationIndex < songs.Count && songs[currentDestinationIndex] != null)
            {
                audioSource.clip = songs[currentDestinationIndex];
                audioSource.Play();

                // Wait until the song finishes playing
                while (audioSource.isPlaying)
                {
                    // Occasionally set a new random target within the roam radius while the song is playing
                    if (Random.Range(0, 100) < 10) // 10% chance to choose a new random target
                    {
                        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
                        randomDirection += targetDestination;
                        NavMeshHit hit;
                        if (NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas))
                        {
                            navMeshAgent.SetDestination(hit.position);
                        }
                    }
                    yield return null;
                }
            }

            // Move to the next destination
            currentDestinationIndex++;
        }
    }
}
