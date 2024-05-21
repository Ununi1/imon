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
        //����a��d����Run״̬
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
        //����Ծ���л�����Ծ״̬
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //����ʱ������������ƶ�����������
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
