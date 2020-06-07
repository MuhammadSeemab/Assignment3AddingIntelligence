using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBenchState : IState
{
    public FSM machine;
    public Transform nearestBench;
    
    public void Enter(FSM machine)
    {
        this.machine = machine;
        this.machine.animator.SetBool("isIdle", false);
        this.machine.animator.SetBool("isWalking", true);

        float minDistance = 1000;
        foreach(Transform bench in machine.benches)
        {
           if(Vector3.Distance(machine.transform.position, bench.position) <minDistance)
            {
                minDistance = Vector3.Distance(machine.transform.position, bench.position);
                nearestBench = bench;
            }
        }
    } 
    public void Execute()
    {
        machine.agent.SetDestination(nearestBench.position);
        if (machine.agent.remainingDistance <= machine.agent.stoppingDistance)
        {
            machine.ChangeState(new SittingState());
            //currentPoints = Random.Range(0, machine.Points.Length);
        } 
    }
    public void Exit()
    {
        
    }
}
