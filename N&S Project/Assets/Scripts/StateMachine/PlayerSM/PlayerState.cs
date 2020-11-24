using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected StateMachine _stateMachine;
    protected PlayerManager _playerManager;

    public PlayerState(StateMachine stateMachine, PlayerManager playerManager)
    {
        _stateMachine = stateMachine;
        _playerManager = playerManager;
    }
}
