using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer;

    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
      stateMachine.InputReader.jumpEvent += OnJump;  
    }

    public override void Tick(float deltaTime)
    {
        
        
        timer -= deltaTime;
        Debug.Log(timer);        
    }

    public override void Exit()
    {
        stateMachine.InputReader.jumpEvent -= OnJump;
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }
}
