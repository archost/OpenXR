using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageController : MonoBehaviour
{
    public List<Stage> stages;

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
        if (stages.Count != 0)
        {
            // set initial positions for objects
            currentStageIndex = 0;
            OnStageSwitch?.Invoke(CurrentStage);
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
