using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态机类
/// </summary>
public class StateMachine : MonoBehaviour
{
    //该类的功能：1，拥有所有状态类，并对它们进行管理和切换
    //2，负责当前状态的更新

    IState currentState;

    protected Dictionary<System.Type, IState> stateTable;

    private void Update()
    {
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    //用于状态启动，传入一个新状态
    protected void SwitchOn(IState newState)
    {
        //将当前状态设置为新状态
        currentState = newState;
        //启动新状态
        currentState.Enter();
    }
    //用于状态切换，传入一个新状态
    public void SwitchState(IState newState)
    {
        //退出当前状态
        currentState.Exit();
        //切换状态并启动

        //currentState = newState;
        //currentState.Enter();

        SwitchOn(newState);
    }
    public void SwitchState(System.Type newType)
    {
        //退出当前状态
        currentState.Exit();
        //使用字典里的值切换状态
        SwitchOn(stateTable[newType]);
    }
}
