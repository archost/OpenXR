using UnityEngine;

[CreateAssetMenu(fileName ="NewStage", menuName ="Stage")]
public class Stage : ScriptableObject
{
    public int ID;

    public string description;

    [Header("Work in progress")]
    public GameObject AttachedObject;
}
