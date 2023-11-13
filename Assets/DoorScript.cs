using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float rotationSpeed = 90f; // Adjust the speed of the door rotation
    public float interactionDistance = 2f; // Adjust the distance at which the player can interact with the door

    private bool isOpen = false;
    private Vector3 pivotPoint;

    private void Start()
    {
        // Set the pivot point as the left corner of the door
        pivotPoint = transform.TransformPoint(Vector3.left * transform.localScale.x / 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToggleDoor();
        }
    }

    private void TryToggleDoor()
    {
        // Check if the player is close enough to the door
        if (IsPlayerNear())
        {
            ToggleDoor();
        }
    }

    private bool IsPlayerNear()
    {
        // Assuming the player tag is "Player". Adjust accordingly.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }

        return false;
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;

        float targetAngle = isOpen ? 90f : 0f;

        // Rotate the door smoothly
        StartCoroutine(RotateDoor(targetAngle));
    }

    private IEnumerator RotateDoor(float targetAngle)
    {
        float currentAngle = transform.localEulerAngles.y;

        while (Mathf.Abs(currentAngle - targetAngle) > 0.1f)
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.RotateAround(pivotPoint, Vector3.up, currentAngle - transform.localEulerAngles.y);
            yield return null;
        }
    }
}