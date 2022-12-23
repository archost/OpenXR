using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Outline), typeof(Rigidbody))]
public class Part : MonoBehaviour
{
    private Outline outline;
    private Rigidbody rb;
    private AudioSource audioSource;
    //private Collider col;
    private PartAnimationController animationController;

    public int PartID { get; private set; }

    [SerializeField]
    private List<JointPoint> jointPoints;

    [SerializeField]
    private PartState state;

    [SerializeField]
    private PartData partData;

    public void ToogleJointPoint(int index)
    {
        if (index >= 0 && index < jointPoints.Count)
        {
            jointPoints[index].gameObject.SetActive(true);
            jointPoints[index].OnPartAttached += AttachPart;
        }
    }

    public void AttachPart(Part part, Vector3 offset)
    {
        Debug.Log($"Part attaching {part.PartID}");
        part.transform.parent = transform;
        part.transform.localPosition = offset;
        part.transform.localEulerAngles = Vector3.zero;
        part.Attach();
    }

    public void Attach()
    {
        UpdateState(PartState.Fixed);
        if (animationController != null) animationController.ToogleAnimator();
    }

    public void Install()
    {
        UpdateState(PartState.Installed);
        if (audioSource != null) audioSource.Play();
    }

    [ContextMenu("Test")]
    public void Test()
    {
        ToogleJointPoint(0);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animationController = GetComponent<PartAnimationController>();
        //col = GetComponent<Collider>();

        outline = GetComponent<Outline>();
        outline.OutlineColor = ProjectPreferences.instance.outlineColor;
        outline.OutlineWidth = ProjectPreferences.instance.outlineWidth;

        if (partData == null)
        {
            Debug.LogError("Part has null PartData!", this.gameObject);
            PartID = 0;
        }
        else
        {
            PartID = partData.ID;
            
        }
        foreach (var p in jointPoints)
        {
            p.gameObject.SetActive(false);
        }
        UpdateState(state);
        
    }

    private void UpdateState(PartState newState)
    {
        state = newState;
        switch (newState)
        {
            case PartState.Idle:
                rb.isKinematic = false;
                outline.enabled = false;
                break;
            case PartState.Holding:
                rb.isKinematic = false;
                outline.enabled = false;
                break;
            case PartState.Fixed:
                rb.isKinematic = true;
                outline.enabled = true;
                break;
            case PartState.Installed:
                rb.isKinematic = true;
                outline.enabled = false;
                break;
            default:
                Debug.LogError("Wrong newState type");
                return;
        }
    }
}

public enum PartState
{
    Idle,
    Holding,
    Fixed,
    Installed
}
