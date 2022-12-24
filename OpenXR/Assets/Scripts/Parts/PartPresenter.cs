using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartPresenter : Collegue
{
    public UnityAction<int> OnJointPointToogle;

    public PartPresenter(Mediator mediator) : base(mediator) { }

    public override void Send(Command command, Collegue target)
    {
        mediator.Send(command, target);
    }

    public override void Notify(Command command)
    {
        if (command is CommandToogleJP)
        {
            CommandToogleJP commandToogleJP = command as CommandToogleJP;
            OnJointPointToogle?.Invoke(commandToogleJP.JointPointID);
        }
    }
}
