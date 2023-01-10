using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartAttacher : MonoBehaviour
{
    public UnityAction<Part> OnPartAttached;

    [SerializeField]
    private List<JointPoint> jointPoints;

    [ContextMenu("Test")]
    public void Test()
    {
        ToogleJointPoint(0);
    }

    public void ToogleJointPoint(int index)
    {
        if (index >= 0 && index < jointPoints.Count)
        {
            jointPoints[index].gameObject.SetActive(true);
            //jointPoints[index].OnPartAttached += AttachPart;
        }
    }

    public void AttachPart(Part part, Vector3 offset, Quaternion rotation, bool toBeFixed)
    {
        if (toBeFixed)
        {
            Debug.Log($"Part attaching {part.PartID}");
            if (part.GrabInteractable != null) part.GrabInteractable.enabled = false;
            part.transform.SetParent(transform);
            part.transform.localPosition = offset;
            part.transform.localEulerAngles = rotation.eulerAngles;
            part.Attach();
            OnPartAttached?.Invoke(part);
        }
        else
        {
            part.transform.SetParent(transform);
            part.transform.localPosition = offset;
            part.transform.localEulerAngles = rotation.eulerAngles;
        }
        
    }

    private void Awake()
    {
        foreach (var p in jointPoints)
        {
            p.OnPartAttached += AttachPart;
            p.gameObject.SetActive(false);
        }
    }
}
