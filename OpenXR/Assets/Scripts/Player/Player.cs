using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private List<string> Items = new List<string>();

    [SerializeField]
    private List<string> expectedItems = new List<string>();

    [SerializeField]
    private UnityEvent OnSecurityEquipped;

    public bool IsReady { get; private set; }

    AudioSource a_s;

    private void Start()
    {
        IsReady = false;
        a_s = GetComponent<AudioSource>();
    }

    [ContextMenu("Equip Everything")]
    public void Test()
    {
        foreach (var item in expectedItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(string item)
    {
        Items.Add(item);
        a_s.Play();

        if (!IsReady && IsFullyEquipped())
        {
            IsReady = true;
            OnSecurityEquipped?.Invoke();
        }
    }

    private bool IsFullyEquipped()
    {
        foreach (var item in expectedItems)
        {
            if (!Items.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

}
