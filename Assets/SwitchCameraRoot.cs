using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCameraRoot : MonoBehaviour
{
    public Transform playerCameraRoot1;
    public Transform playerCameraRoot2;

    private CinemachineVirtualCamera virtualCamera;
    private bool isCameraRoot1Active = true;

    void Start()
    {
        // Ensure the script is attached to a CinemachineVirtualCamera
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera == null)
        {
            Debug.LogError("SwitchCameraRoot script must be attached to a CinemachineVirtualCamera.");
            return;
        }

        // Ensure both playerCameraRoots are assigned
        if (playerCameraRoot1 == null || playerCameraRoot2 == null)
        {
            Debug.LogError("Please assign both PlayerCameraRoot objects in the inspector.");
            return;
        }

        // Set the initial camera root
        SetActiveCameraRoot();
    }

    void Update()
    {
        // Check for input to switch camera roots
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Toggle between camera roots
            isCameraRoot1Active = !isCameraRoot1Active;

            // Set the active camera root
            SetActiveCameraRoot();
        }
    }

    void SetActiveCameraRoot()
    {
        // Set the active camera root based on the current state
        if (isCameraRoot1Active)
        {
            virtualCamera.Follow = playerCameraRoot1;
            virtualCamera.LookAt = playerCameraRoot1;
        }
        else
        {
            virtualCamera.Follow = playerCameraRoot2;
            virtualCamera.LookAt = playerCameraRoot2;
        }
    }
}