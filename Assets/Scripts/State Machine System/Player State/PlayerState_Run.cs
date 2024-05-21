using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    //���ٶ�
    float acceleration = 5f;
    public override void Enter()
    {
        //����a��d����Run״̬
        //animator.Play("Run");
        base.Enter();
        //�����ܲ�״̬ʱ��¼��ǰ�ٶ�
        currentSpeed = playerController.MoveSpeed;
    }
    public override void Exit()
    {
        //playerController.Move(0);
    }
    public override void LogicUpdate()
    {
        //û���������л�ΪIdle״̬
        if (!playerInput.IsMove)
        {
            //����״̬����״̬�л�����
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        //����Ծ���л�����Ծ״̬
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //�ܵ�ƽ̨��ͽ�������ʱ��
        if (!playerController.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }
        //���ٹ���
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed,acceleration*Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.Move(currentSpeed);
    }
}
