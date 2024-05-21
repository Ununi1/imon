using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlyaerState/Float", fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField]
    VoidEventChannel deathEventChannel;
    [SerializeField]
    float floatingSpeed = 0.5f;

    Vector3 floatingPosition;

    [SerializeField]
    //首先移动到的点
    Vector3 floatingPosingOffset;
    public override void Enter()
    {
        base.Enter();

        deathEventChannel.Broadcast();

        floatingPosition = playerController.transform.position + floatingPosingOffset;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Transform playerTransform = playerController.transform;
        if (Vector3.Distance(playerTransform.position,floatingPosition)>floatingSpeed*Time.deltaTime)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition, floatingSpeed * Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}
