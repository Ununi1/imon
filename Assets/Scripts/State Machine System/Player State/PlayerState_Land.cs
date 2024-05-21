using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField]
    //硬直时间
    float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();

        playerController.SetVelocity(Vector3.zero);

    }
    public override void LogicUpdate()
    {
        //胜利则切换到胜利状态
        if (playerController.victory)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Victory));
        }
        //摁跳跃就切换到跳跃状态
        if(playerInput.HasJumpInputButter||playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //硬直
        if (StateDuration<stiffTime)
        {
            return;
        }
        //落地摁移动键就切换到移动状态
        if (playerInput.IsMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        //落地什么都不干，等待动画播放完就进入站立状态
        if (IsAnimationFinished)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }


}
