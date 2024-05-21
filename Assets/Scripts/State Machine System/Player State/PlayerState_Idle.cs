using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�����ļ�·��
[CreateAssetMenu(menuName ="Data/StateMachine/PlyaerState/Idle",fileName ="PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField]
    float deceleration = 5f;
    public override void Enter()
    {
        //��ʼ��Ϸʱ����Idle״̬
        //animator.Play("Idle");
        base.Enter();
        //����վ��״̬ʱ��¼��ǰ�ٶ�
        currentSpeed = playerController.MoveSpeed;
    }
    //�߼�����
    public override void LogicUpdate()
    {
        //�����ƶ������л�Ϊ�ܲ�״̬
        if (playerInput.IsMove)
        {
            //����״̬����״̬�л�����
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        //����Ծ���л�����Ծ״̬
        if (playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //�ܵ�ƽ̨��Ϳ�ʼ����
        if (!playerController.IsGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        //���ٹ���
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        playerController.SetVelocityX(currentSpeed*playerController.transform.localScale.x);
    }
}
