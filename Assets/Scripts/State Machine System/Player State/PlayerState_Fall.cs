using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField]
    //�ɱ༭�����ߣ����Ի�ȡ���������ϵ�ֵ�������˶��켣
    AnimationCurve speedCurve;
    [SerializeField]
    float moveSpeed = 5f;
    public override void LogicUpdate()
    {
        //�䵽���Ͼ��л������״̬
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
        //����״̬�ĳ���ʱ������ȡ�����ϵ�ֵ
        playerController.SetVelocityY(speedCurve.Evaluate(StateDuration));
        //�����ƶ�
        playerController.Move(moveSpeed);
    }
}
