using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    private Vector2 direction;
    private bool jumping;
    void Start()
    {
    }
    public override void Enter()
    {
        base.Enter();

    }

    public override void InputHandler()
    {
        base.InputHandler();
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        jumping = Input.GetButtonDown("Jump");

    }

    public override void Update()
    {
        base.Update();
        if (direction.x != 0)
        {
            _stateMachine.ChangeState(_playerManager.Moving);
        }

        if (jumping && _playerManager.grounded.IsGrounded())
        {
            _stateMachine.ChangeState(_playerManager.Jumping);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


    public IdleState(StateMachine stateMachine, PlayerManager playerManager) : base(stateMachine, playerManager)
    {
    }
}
