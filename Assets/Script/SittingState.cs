using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingState : IState
{
    public FSM machine;
    private float timer = 0;
    public void Enter(FSM machine)
    {
        this.machine = machine;
        this.machine.animator.SetTrigger("sitDown");  
        this.machine.agent.isStopped = true;
    }
    public void Execute()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            machine.health = 100;
            machine.ChangeState(new StandUpState());
        }

    }
    public void Exit()
    {
        machine.agent.isStopped = false;
    }

}
