using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    public PlayerState idle;
    public PlayerState moving;
    private Rigidbody2D _rb;

    public Rigidbody2D Rb => _rb;


    void Start()
    {
     _stateMachine = new PlayerStateMachine();
     idle = new IdleState(_stateMachine, this);
     moving = new MovingState(_stateMachine, this);
     _rb = GetComponent<Rigidbody2D>();

     _stateMachine.Initialize(idle);
    }
    
    void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }

    private void Update()
    {
        Debug.Log("Current State: " + _stateMachine.CurrentState);
        _stateMachine.CurrentState.Update();
    }

    
}
