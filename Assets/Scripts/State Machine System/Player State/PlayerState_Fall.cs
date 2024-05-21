using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField]
    //可编辑的曲线，可以获取这条曲线上的值来设置运动轨迹
    AnimationCurve speedCurve;
    [SerializeField]
    float moveSpeed = 5f;
    public override void LogicUpdate()
    {
        //落到地上就切换到落地状态
        if (playerController.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Land));
        }
        if (playerInput.Jump)
        {
            if (playerController.CanAirJump)
            {
                playerStateMachine.SwitchState(typeof(PlayerState_AirJump));
            }
            playerInput.SetJumpInputBufferTimer();
        }
    }
    public override void PhysicUpdate()
    {
        //根据状态的持续时间来获取曲线上的值
        playerController.SetVelocityY(speedCurve.Evaluate(StateDuration));
        //空中移动
        playerController.Move(moveSpeed);
    }
}
