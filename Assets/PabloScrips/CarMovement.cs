using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the car to follow
    public float speed = 5f; // Speed of the car
    public float rotationSpeed = 100f; // Speed of rotation
    public float offsetDistance = 5f; // Distance to offset when turning around
    public float waitTime = 3f; // Time to wait at the offset position

    private int currentWaypointIndex = 0;
    private bool isTurningAround = false;

    void Start()
    {
        if (waypoints.Length > 1)
        {
            StartCoroutine(MoveCar());
        }
        else
        {
            Debug.LogError("Not enough waypoints assigned.");
        }
    }

    IEnumerator MoveCar()
    {
        while (true)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];

            // Move the car towards the target waypoint
            while (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
            {
                if (!isTurningAround)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
                }
                yield return null;
            }

            // Check if the car needs to turn around at waypoint index 0 or 1
            if ((currentWaypointIndex == 0 || currentWaypointIndex == 1) && !isTurningAround)
            {
                isTurningAround = true;
                yield return StartCoroutine(TurnAndWait());
                isTurningAround = false;
            }

            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    IEnumerator TurnAndWait()
    {
        // Calculate the offset position to avoid collisions
        Vector3 offsetDirection = (currentWaypointIndex == 0) ? transform.right : -transform.right;
        Vector3 offsetPosition = transform.position + offsetDirection * offsetDistance;

        // Move to the offset position
        while (Vector3.Distance(transform.position, offsetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, offsetPosition, speed * Time.deltaTime);
            yield return null;
        }

        // Rotate the car by 180 degrees
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 180, 0));

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Wait at the offset position
        yield return new WaitForSeconds(waitTime);
    }
}
