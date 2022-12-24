using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandRayController : MonoBehaviour
{
    public static HandRayController instance = null;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    public bool IsRightHovering => rightRay.TryGetHitInfo(out Vector3 RightPos, out Vector3 RightNormal, out int RightNumber, out bool RightValid);

    public bool IsLeftHovering => leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

}
