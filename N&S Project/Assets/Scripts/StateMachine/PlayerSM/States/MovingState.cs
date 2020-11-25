using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovingState : PlayerState
{
    // Start is called before the first frame update
    private Vector2 direction;
    private bool jumping;
    public override void Enter()
    {
        base.Enter();
    }

    public override void InputHandler()
    {
        base.InputHandler();
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        jumping = Input.GetButtonDown("Jump");

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        var speed = 2f;
        _playerManager.Rb.velocity = new Vector2(direction.x * speed* 100* Time.fixedDeltaTime,_playerManager.Rb.velocity.y);

    }

    public override void Update()
    {
        base.Update();
        if (jumping)
        {
            _stateMachine.ChangeState(_playerManager.Jumping);
        }
        if (direction.x == 0)
        {
            _stateMachine.ChangeState(_playerManager.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


    public MovingState(StateMachine stateMachine, PlayerManager playerManager) : base(stateMachine, playerManager)
    {
    }
}
