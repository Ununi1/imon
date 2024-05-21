using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Defeated", fileName = "PlayerState_Defeated")]
public class PlayerState_Defeated : PlayerState
{
    [SerializeField]
    ParticleSystem VFX;

    [SerializeField]
    AudioClip[] voice;
    public override void Enter()
    {
        base.Enter();

        //Instantiate(VFX, playerController.transform.position, Quaternion.identity);

        AudioClip deathVoice = voice[Random.Range(0, voice.Length)];

        playerController.AudioSource.PlayOneShot(deathVoice);
    }
    /// <summary>
    /// 动画播放完成切换
    /// </summary>
    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }
}
