using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpState : IState
{
    public FSM machine;
    private float timer = 0;
    public void Enter(FSM machine)
    {
        this.machine = machine;
        this.machine.animator.SetTrigger("standUp");
    }
    public void Execute()
    {
        timer += Time.deltaTime;
        if(timer > this.machine.animator.GetCurrentAnimatorStateInfo(0).length)
        {
            machine.ChangeState(new PatrolState());
        }

    }
    public void Exit()
    {

    }
}
