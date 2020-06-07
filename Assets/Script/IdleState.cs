using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public FSM machine; 
    private float timer = 0;
   public void Enter(FSM machine)
   {
       this.machine = machine;
       this.machine.animator.SetBool("isIdle", true);
       this.machine.animator.SetBool("isWalking", false);
        this.machine.agent.isStopped = true;
    }
   public void Execute()
   {
        machine.health -= 2 * Time.deltaTime;
       timer += Time.deltaTime;
       
       if(timer >= 5)
       
           machine.ChangeState(new PatrolState());
       if(machine.health < 10)
        {
            machine.ChangeState(new GoToBenchState());
        }
        
        //Debug.Log("Idle");
   }
   public void Exit()
   {
        machine.agent.isStopped = false;
   }
}
