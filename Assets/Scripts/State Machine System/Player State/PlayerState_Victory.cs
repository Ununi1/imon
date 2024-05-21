using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Victory", fileName = "PlayerState_Victory")]
public class PlayerState_Victory : PlayerState
{
    [SerializeField]
    AudioClip[] audioClip;
    public override void Enter()
    {
        base.Enter();

        playerInput.DisableInputs();

        playerController.AudioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
    }
}
