using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    private PlayerStateMachine _stateMachine;
    public PlayerState Idle;
    public PlayerState Moving;
    public PlayerState Jumping;
    private Rigidbody2D _rb; 
    public Grounded grounded;
    public Rigidbody2D Rb => _rb;


    void Start()
    {
        grounded = GetComponent<Grounded>();
     _stateMachine = new PlayerStateMachine();
     Idle = new IdleState(_stateMachine, this);
     Moving = new MovingState(_stateMachine, this);
     Jumping = new JumpingState(_stateMachine,this);
     _rb = GetComponent<Rigidbody2D>();
     _stateMachine.Initialize(Idle);
    }
    private void Update()
    {
        Debug.Log("Current State: " + _stateMachine.CurrentState);
        Debug.Log("Grounded: " + grounded.IsGrounded());
        _stateMachine.CurrentState.InputHandler();
        _stateMachine.CurrentState.Update();
    }
    void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }



    
}
