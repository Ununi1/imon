using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ״̬����
/// </summary>
public class StateMachine : MonoBehaviour
{
    //����Ĺ��ܣ�1��ӵ������״̬�࣬�������ǽ��й�����л�
    //2������ǰ״̬�ĸ���

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

    //����״̬����������һ����״̬
    protected void SwitchOn(IState newState)
    {
        //����ǰ״̬����Ϊ��״̬
        currentState = newState;
        //������״̬
        currentState.Enter();
    }
    //����״̬�л�������һ����״̬
    public void SwitchState(IState newState)
    {
        //�˳���ǰ״̬
        currentState.Exit();
        //�л�״̬������

        //currentState = newState;
        //currentState.Enter();

        SwitchOn(newState);
    }
    public void SwitchState(System.Type newType)
    {
        //�˳���ǰ״̬
        currentState.Exit();
        //ʹ���ֵ����ֵ�л�״̬
        SwitchOn(stateTable[newType]);
    }
}
