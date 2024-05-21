using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/AirJump", fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [SerializeField]
    float jumpFroce = 7f;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    ParticleSystem jumpVFX;
    [SerializeField]
    AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        playerController.CanAirJump = false;
        playerController.SetVelocityY(jumpFroce);

        //播放特效
        //Instantiate(jumpVFX, playerController.transform.position, Quaternion.identity);
        //播放音效
        playerController.AudioSource.PlayOneShot(jumpSFX);
    }
    public override void LogicUpdate()
    {
        //如果落下或者松开跳跃键则切换到落下状态
        if (playerController.IsFalling || playerInput.StopJump)
        {
            //跳起状态只会转换到落下状态
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        //空中移动
        playerController.Move(moveSpeed);
    }
}
