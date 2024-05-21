using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//创建文件路径
[CreateAssetMenu(menuName ="Data/StateMachine/PlyaerState/Idle",fileName ="PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField]
    float deceleration = 5f;
    public override void Enter()
    {
        //开始游戏时进入Idle状态
        //animator.Play("Idle");
        base.Enter();
        //进入站立状态时记录当前速度
        currentSpeed = playerController.MoveSpeed;
    }
    //逻辑更新
    public override void LogicUpdate()
    {
        //摁下移动键则切换为跑步状态
        if (playerInput.IsMove)
        {
            //调用状态机的状态切换方法
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        //摁跳跃就切换到跳跃状态
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //跑到平台外就开始下落
        if (!playerController.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        //减速过程
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.SetVelocityX(currentSpeed*playerController.transform.localScale.x);
    }
}
