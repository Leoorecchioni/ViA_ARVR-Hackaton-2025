using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public AudioSource EndingHidden;
    public AudioSource EndingWarning;
    public AudioSource EndingCaught;
    public GameObject player;
    public float gotoX;
    public float gotoY;
    public float gotoZ;

    private bool audioStarted = false;
    private bool hasActivated = false;

    void Update()
    {
        if (!hasActivated)
        {
            if (!audioStarted && (EndingHidden.isPlaying || EndingWarning.isPlaying || EndingCaught.isPlaying))
            {
                audioStarted = true;
            }

            if (audioStarted &&
                !EndingHidden.isPlaying &&
                !EndingWarning.isPlaying &&
                !EndingCaught.isPlaying)
            {
                if (player != null)
                {
                    player.transform.position = new Vector3(gotoX, gotoY, gotoZ);
                }

                hasActivated = true;
            }
        }
    }
}
