using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JointPoint : MonoBehaviour
{
    private Collider col;

    public bool IsEnabled { get; private set; }

    [SerializeField]
    private int suitablePartID;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Part p))
        {
            Debug.Log($"Met Part#{p.PartID}");
        } 
    }
}
