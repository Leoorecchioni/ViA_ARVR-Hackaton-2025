using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class ConstrainToAxis : MonoBehaviour
{
    public enum Axis { X, Y, Z }
    public Axis lockAxis = Axis.Y;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor;
    private Vector3 initialOffset;

    private void OnEnable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().selectEntered.AddListener(OnGrab);
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().selectEntered.RemoveListener(OnGrab);
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject.transform.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>();
        initialOffset = transform.position - interactor.transform.position;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        interactor = null;
    }

    private void Update()
    {
        if (interactor != null)
        {
            Vector3 targetPosition = interactor.transform.position + initialOffset;
            Vector3 currentPosition = transform.position;

            // Lock axes
            switch (lockAxis)
            {
                case Axis.X:
                    targetPosition.y = currentPosition.y;
                    targetPosition.z = currentPosition.z;
                    break;
                case Axis.Y:
                    targetPosition.x = currentPosition.x;
                    targetPosition.z = currentPosition.z;
                    break;
                case Axis.Z:
                    targetPosition.x = currentPosition.x;
                    targetPosition.y = currentPosition.y;
                    break;
            }

            transform.position = targetPosition;
        }
    }
}
