using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField]
    float jumpFroce=7f;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    ParticleSystem jumpVFX;
    [SerializeField]
    AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        playerController.SetVelocityY(jumpFroce);

        playerInput.HasJumpInputButter = false;
        //������Ч
        //Instantiate(jumpVFX, playerController.transform.position, Quaternion.identity);
        //������Ч
        playerController.AudioSource.PlayOneShot(jumpSFX);
    }
    public override void LogicUpdate()
    {
        //������»����ɿ���Ծ�����л�������״̬
        if (playerController.IsFalling||playerInput.StopJump)
        {
            //����״ֻ̬��ת��������״̬
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        //�����ƶ�
        playerController.Move(moveSpeed);
    }
}
