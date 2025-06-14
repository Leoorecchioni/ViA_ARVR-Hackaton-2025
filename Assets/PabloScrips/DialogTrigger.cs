using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioClip song; // Assign your song in the Inspector
    public GameObject npc; // Assign your NPC GameObject in the Inspector
    private bool isPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("je rentre");
        // Check if the object entering the trigger is the specific NPC
        if (other.gameObject == npc)
        {
            StartDialogueOrSong();
        }
    }

    void StartDialogueOrSong()
    {
        // Get the AudioSource component attached to the same GameObject
        AudioSource audioSource = GetComponent<AudioSource>();

        // Check if the AudioSource and the song are not null
        if (audioSource != null && song != null && isPlayed == false)
        {
            // Assign the song clip to the AudioSource
            audioSource.clip = song;

            // Play the song
            audioSource.Play();
            isPlayed = true;
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is not assigned.");
        }
    }
}
