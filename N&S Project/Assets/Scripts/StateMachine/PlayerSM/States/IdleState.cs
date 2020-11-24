using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    void Start()
    {
    }
    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        if (Input.GetAxis("Horizontal") != 0)
        {
            _stateMachine.ChangeState(_playerManager.moving);
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
