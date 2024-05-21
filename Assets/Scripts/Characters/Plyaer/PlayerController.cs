using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 常规方法
    //Animator animator;

    ////获取动画组件
    //private void Awake()
    //{
    //    animator = GetComponentInChildren<Animator>();
    //}

    //private void Update()
    //{
    //    if (Keyboard.current.aKey.isPressed|| Keyboard.current.dKey.isPressed)
    //    {
    //        animator.Play("Run");
    //    }
    //    else
    //    {
    //        animator.Play("Idle");
    //    }
    //}
    #endregion

    PlayerInput playerInput;

    Rigidbody rigidbody;

    PlayerGroundDetector groundDetector;
    //获取移动速度
    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);
    //是否在地面
    public bool IsGrounded => groundDetector.IsGround;
    //是否在掉落
    public bool IsFalling => rigidbody.velocity.y < 0 && !IsGrounded;
    //能否在空中跳跃
    public bool CanAirJump { get; set; }

    public bool victory { get; private set; }

    public AudioSource AudioSource { get;private set; }

    [SerializeField]
    VoidEventChannel levelClearedEventChannel;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();

        AudioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        //启用输入表
        playerInput.EnableGamePlayInputs();
    }
    //Todo：在死亡/游戏结束时禁用Gameplay输入表

    //通关
    void levelCleared()
    {
        victory = true;
    }

    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(levelCleared);
    }
    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(levelCleared);
    }
    
    public void Move(float speed)
    {
        if (playerInput.IsMove)
        {
            transform.localScale = new Vector3(playerInput.Axisx, 1, 1);
        }
        SetVelocityX(speed * playerInput.Axisx);
    }
    /// <summary>
    /// 设置速度
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }
    /// <summary>
    /// 设置X轴的速度
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3(velocityX, rigidbody.velocity.y);
    }
    /// <summary>
    /// 设置Y轴的速度
    /// </summary>
    /// <param name="velocityY"></param>
    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x,velocityY);
        
    }
    //是否启用重力
    public void SetUseGravity(bool value)
    {
        rigidbody.useGravity = value;
    }
    //失败事件
    public void OnDefeated()
    {
        playerInput.DisableInputs();

        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        rigidbody.detectCollisions = false;

        GetComponent<PlayerStateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }
}
