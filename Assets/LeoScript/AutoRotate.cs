using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Par défaut, tourne autour de l'axe Y
    public float rotationSpeed = 45f; // Degrés par seconde

    void Update()
    {
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
    }
}
