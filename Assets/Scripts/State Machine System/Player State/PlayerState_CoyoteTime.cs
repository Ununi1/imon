using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float coyoteTime=0.1f;

    public override void Enter()
    {
        //按下a，d进入Run状态
        //animator.Play("Run");
        base.Enter();

        playerController.SetUseGravity(false);
    }
    public override void Exit()
    {
        //playerController.Move(0);
        playerController.SetUseGravity(true);
    }
    public override void LogicUpdate()
    {
        //摁跳跃就切换到跳跃状态
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //土狼时间结束或不输入移动按键就下落
        if (StateDuration>coyoteTime|| !playerInput.IsMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        
    }
    public override void PhysicUpdate()
    {
        playerController.Move(runSpeed);
    }
}
