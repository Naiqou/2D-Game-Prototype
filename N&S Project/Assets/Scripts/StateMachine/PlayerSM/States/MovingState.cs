using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovingState : PlayerState
{
    // Start is called before the first frame update
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void PhysicsUpdate()
    {
        base.Update();
        var direction = new Vector2(Input.GetAxis("Horizontal"),0);
        float speed = 2f;
        _playerManager.Rb.velocity = direction * speed * 100 * Time.fixedDeltaTime;
        if (direction.x == 0)
        {
            _stateMachine.ChangeState(_playerManager.idle);
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
