using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class FSM : MonoBehaviour
{
    public IState currentState;
    public Animator animator;

    public Transform[] Points;
    public NavMeshAgent agent;

    public float health = 100;
    public Slider healthBar;
   
    public Transform[] benches;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
        healthBar.value = health;
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }
}
