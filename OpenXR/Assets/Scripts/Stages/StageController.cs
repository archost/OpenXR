using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PartFactory))]
public class StageController : MonoBehaviour
{
    private Mediator mediator;
    private StageControllerPresenter scp;

    public List<Stage> stages;

    private PartFactory partFactory;

    private int currentStageIndex = -1;

    private Stage CurrentStage
    { 
        get 
        { 
            if (currentStageIndex <= stages.Count - 1)
                return stages[currentStageIndex]; 
            else
                return null;
        } 
    }

    public UnityAction<Stage> OnStageSwitch;

    private void Start()
    {
        partFactory = GetComponent<PartFactory>();

        mediator = new Mediator();
        scp = new StageControllerPresenter(mediator);
        mediator.StageControllerPresenter = scp;
        scp.OnPartFinished += ProcessInstallFinished;

        partFactory.SpawnParts(mediator);

        if (stages.Count != 0)
        {
            // set initial positions for objects
            currentStageIndex = 0;
            OnStageSwitch?.Invoke(CurrentStage);
        }
    }

    private void ProcessInstallFinished(CommandFinished command)
    {
        if (command.Sender is PartPresenter)
        {
            var pp = command.Sender as PartPresenter;
            Debug.Log($"Attached {pp.PartData.name}!");
        }
    }

    public void NextStage()
    {
        if (currentStageIndex < stages.Count)
        {
            currentStageIndex++;
            OnStageSwitch?.Invoke(CurrentStage);
        }
    }

    public void PrevStage()
    {
        // work in progress
    }
}
