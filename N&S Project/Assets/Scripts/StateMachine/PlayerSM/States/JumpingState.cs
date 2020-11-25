using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState
{
    private bool _jumped;
    public override void Update()
    {
        base.Update();
        var jumpVelocity = 10f;
        if (_playerManager.grounded.IsGrounded() && !_jumped)
        {
            _playerManager.Rb.velocity = Vector2.up * jumpVelocity;
            _jumped = true;
        }


        if (_playerManager.grounded.IsGrounded() && _jumped)
        {
            _jumped = false;
            _stateMachine.ChangeState(_playerManager.Idle);
        }
        else if (_playerManager.Rb.velocity.x != 0 && _jumped)
        {
            _jumped = false;
            _stateMachine.ChangeState(_playerManager.Moving);
        }

    }
    

    public JumpingState(StateMachine stateMachine, PlayerManager playerManager) : base(stateMachine, playerManager)
    {
    }
}
