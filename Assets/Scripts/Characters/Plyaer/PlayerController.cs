using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region ���淽��
    //Animator animator;

    ////��ȡ�������
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
    //��ȡ�ƶ��ٶ�
    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);
    //�Ƿ��ڵ���
    public bool IsGrounded => groundDetector.IsGround;
    //�Ƿ��ڵ���
    public bool IsFalling => rigidbody.velocity.y < 0 && !IsGrounded;
    //�ܷ��ڿ�����Ծ
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
        //���������
        playerInput.EnableGamePlayInputs();
    }
    //Todo��������/��Ϸ����ʱ����Gameplay�����

    //ͨ��
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
    /// �����ٶ�
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }
    /// <summary>
    /// ����X����ٶ�
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3(velocityX, rigidbody.velocity.y);
    }
    /// <summary>
    /// ����Y����ٶ�
    /// </summary>
    /// <param name="velocityY"></param>
    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x,velocityY);
        
    }
    //�Ƿ���������
    public void SetUseGravity(bool value)
    {
        rigidbody.useGravity = value;
    }
    //ʧ���¼�
    public void OnDefeated()
    {
        playerInput.DisableInputs();

        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        rigidbody.detectCollisions = false;

        GetComponent<PlayerStateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }
}
