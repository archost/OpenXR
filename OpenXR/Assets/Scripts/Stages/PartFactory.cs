using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PartFactory : MonoBehaviour
{
    [SerializeField]
    private List<SpawnInfo> spawnInfos = new List<SpawnInfo>();

    public void SpawnParts(Mediator mediator)
    {
        foreach (var s in spawnInfos)
        {
            Part p = Instantiate(s.partPrefab);
            var presenter = p.InitPartPresenter(mediator);
            mediator.AddPart(presenter);
            s.point.ForceAttach(p, false);
        }
        Debug.Log($"Spawn complete! ({spawnInfos.Count} instances)");
    }


    [System.Serializable]
    private struct SpawnInfo
    {
        public Part partPrefab;
        public JointPoint point;
    }
}