using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    [SerializeField]
    string stateName;
    [SerializeField,Range(0f,1f)]
    float transitionDuration = 0.1f;
    //状态的哈希值
    int stateHash;

    float stateStartTime;

    protected Animator animator;
    //用于玩家状态的切换
    protected PlayerStateMachine playerStateMachine;

    protected PlayerController playerController;

    protected PlayerInput playerInput;

    protected float currentSpeed;
    //判断动画是否播放完成：当前动画的持续时间是否大于当前动画状态的长度
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    //状态持续时间
    protected float StateDuration => Time.time - stateStartTime;

    private void OnEnable()
    {
        //传入Animator中动画的名字，转换为Hash
        stateHash = Animator.StringToHash(stateName);
    }
    /// <summary>
    /// 用传入值初始化变量 
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
