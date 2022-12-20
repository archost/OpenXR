using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Outline), typeof(Rigidbody))]
public class Part : MonoBehaviour
{
    private Outline outline;
    private Rigidbody rb;
    private Animator animator;
    //private Collider col;

    public int PartID { get; private set; }

    [SerializeField]
    private List<JointPoint> jointPoints;

    [SerializeField]
    private PartState state;

    [SerializeField]
    private PartData partData;

    [SerializeField]
    private int action;

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
        Debug.Log($"Part attaching {part.PartID}, {offset}");
        part.transform.parent = transform;
        part.transform.localPosition = offset;
        part.Attach();
    }

    public void Attach()
    {
        UpdateState(PartState.Fixed);
    }

    private void Update()
    {
        //TODO rework
        if (action != 0) 
        { 
            if (animator != null) 
            {
                animator.enabled = true;
                animator.SetInteger("action", action); 
            } 
        }
        
    }

    [ContextMenu("Test")]
    public void Test()
    {
        ToogleJointPoint(0);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //TODO rework
        if(animator!= null) animator.enabled = false;
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
