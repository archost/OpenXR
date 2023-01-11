using UnityEngine;

[CreateAssetMenu(fileName ="NewStage", menuName ="Stage")]
public class Stage : ScriptableObject
{
    public int ID;

    public string description;

    public PartData target;

    public JointPoint destination;

    [Header("Optional")]
    public PartData destinationPart;

    public int jointPointIndex;
}
