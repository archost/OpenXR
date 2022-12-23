using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject rightTeleportation;
    public GameObject leftTeleportation;

    public InputActionProperty rightActivate;
    public InputActionProperty leftActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    void Update()
    {
        bool isRightHovering = HandRayController.instance.IsRightHovering;
        
        rightTeleportation.SetActive(!isRightHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);

        bool isLeftHovering = HandRayController.instance.IsLeftHovering;

        leftTeleportation.SetActive(!isLeftHovering && leftCancel.action.ReadValue<float>() == 0f && leftActivate.action.ReadValue<float>() > 0.1f);
    }
}
