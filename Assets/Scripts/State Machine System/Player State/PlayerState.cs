using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    [SerializeField]
    string stateName;
    [SerializeField,Range(0f,1f)]
    float transitionDuration = 0.1f;
    //״̬�Ĺ�ϣֵ
    int stateHash;

    float stateStartTime;

    protected Animator animator;
    //�������״̬���л�
    protected PlayerStateMachine playerStateMachine;

    protected PlayerController playerController;

    protected PlayerInput playerInput;

    protected float currentSpeed;
    //�ж϶����Ƿ񲥷���ɣ���ǰ�����ĳ���ʱ���Ƿ���ڵ�ǰ����״̬�ĳ���
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    //״̬����ʱ��
    protected float StateDuration => Time.time - stateStartTime;

    private void OnEnable()
    {
        //����Animator�ж��������֣�ת��ΪHash
        stateHash = Animator.StringToHash(stateName);
    }
    /// <summary>
    /// �ô���ֵ��ʼ������ 
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="playerStateMachine"></param>
    public void Initialize(Animator animator, PlayerController playerController,PlayerInput playerInput,PlayerStateMachine playerStateMachine)
    {
        this.animator = animator;
        this.playerInput = playerInput;
        this.playerStateMachine = playerStateMachine;
        this.playerController = playerController;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash,transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
