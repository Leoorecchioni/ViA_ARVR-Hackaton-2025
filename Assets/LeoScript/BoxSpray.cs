using UnityEngine;

public class BoxSpray : MonoBehaviour
{
    [Header("Paramètres")]
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject objectToShow;

    private bool hasBeenActivated = false;

    void Start()
    {
        // Cacher l'objet au démarrage
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Aucun objet à afficher n'a été assigné au script BoxSpray !");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si le trigger est avec l'objet cible et si l'objet n'a pas déjà été activé
        if (!hasBeenActivated && (targetObject == null || other.gameObject == targetObject))
        {
            hasBeenActivated = true;
            if (objectToShow != null)
            {
                objectToShow.SetActive(true);
            }
        }
    }
}
