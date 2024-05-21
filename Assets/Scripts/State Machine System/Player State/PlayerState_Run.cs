using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    //加速度
    float acceleration = 5f;
    public override void Enter()
    {
        //按下a，d进入Run状态
        //animator.Play("Run");
        base.Enter();
        //进入跑步状态时记录当前速度
        currentSpeed = playerController.MoveSpeed;
    }
    public override void Exit()
    {
        //playerController.Move(0);
    }
    public override void LogicUpdate()
    {
        //没有输入则切换为Idle状态
        if (!playerInput.IsMove)
        {
            //调用状态机的状态切换方法
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        //摁跳跃就切换到跳跃状态
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //跑到平台外就进行土狼时间
        if (!playerController.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }
        //加速过程
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed,acceleration*Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.Move(currentSpeed);
    }
}
