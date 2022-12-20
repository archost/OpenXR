using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class JointPoint : MonoBehaviour
{
    private Collider col;

    public bool IsEnabled { get; private set; }

    [SerializeField]
    private int suitablePartID;

    [SerializeField]
    private Vector3 offset = Vector3.zero;

    public UnityAction<Part, Vector3> OnPartAttached;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Part p))
        {
            if (p.PartID == suitablePartID)
            {
                OnPartAttached?.Invoke(p, transform.localPosition + offset);
                gameObject.SetActive(false);
            }
        } 
    }
}
