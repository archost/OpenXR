using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // public XRRayInteractor leftRay;
    // public XRRayInteractor rightRay;

    // public InputActionProperty rightActivate;
    // public InputActionProperty leftActivate;

    private void Update()
    {
        /*
        bool isRightHovering = rightRay.TryGetHitInfo(out Vector3 RightPos, out Vector3 RightNormal, out int RightNumber, out bool RightValid);
        bool isLeftHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        
        if (animator != null)
        {
            if ((isRightHovering && rightActivate.action.ReadValue<float>() > 0.1f) || (isLeftHovering && leftActivate.action.ReadValue<float>() > 0.1f))
            {
                animator.speed = 1;
            }
            else
            {
                animator.speed = 0;
            }
        }
        */

        if (animator != null)
        {
            if (animator.GetBool("Play") == true)
            {
                animator.speed = 1;
            }
            else
            {
                animator.speed = 0;
            }
        }
    }
}
