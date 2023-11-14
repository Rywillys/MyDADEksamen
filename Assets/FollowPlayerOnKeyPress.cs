using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    private bool isPlayerSitting = false;
    private Transform playerTransform;
    private Vector3 playerOffset = new Vector3(0f, 1f, 0f); // Offset to adjust player position while sitting

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isPlayerSitting)
            {
                StartCoroutine(SitOnCube());
            }
            else
            {
                StandUpFromCube();
            }
        }
    }

    IEnumerator SitOnCube()
    {
        // Save the player's current position and rotation
        playerTransform = Camera.main.transform;
        Vector3 originalPosition = playerTransform.position;
        Quaternion originalRotation = playerTransform.rotation;

        // Calculate the sitting position
        Vector3 sittingPosition = transform.position + playerOffset;

        // Move and rotate the player to the sitting position
        while (Vector3.Distance(playerTransform.position, sittingPosition) > 0.1f)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position, sittingPosition, Time.deltaTime * 5f);
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, transform.rotation, Time.deltaTime * 5f);
            yield return null;
        }

        // Set the flag to indicate the player is sitting
        isPlayerSitting = true;
    }

    void StandUpFromCube()
    {
        // Reset player's position and rotation
        playerTransform.position -= playerOffset;
        playerTransform.rotation = Quaternion.identity;

        // Set the flag to indicate the player is not sitting
        isPlayerSitting = false;
    }
}