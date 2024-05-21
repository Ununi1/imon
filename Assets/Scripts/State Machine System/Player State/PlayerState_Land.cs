using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField]
    //Ӳֱʱ��
    float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();

        playerController.SetVelocity(Vector3.zero);

    }
    public override void LogicUpdate()
    {
        //ʤ�����л���ʤ��״̬
        if (playerController.victory)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Victory));
        }
        //����Ծ���л�����Ծ״̬
        if(playerInput.HasJumpInputButter||playerInput.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //Ӳֱ
        if (StateDuration<stiffTime)
        {
            return;
        }
        //������ƶ������л����ƶ�״̬
        if (playerInput.IsMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        //���ʲô�����ɣ��ȴ�����������ͽ���վ��״̬
        if (IsAnimationFinished)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }


}
