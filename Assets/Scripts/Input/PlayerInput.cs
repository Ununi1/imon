using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 这个类专门用来处理Input system的输入 
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float jumpInputBufferTime = 0.3f;

    WaitForSeconds waitJumpTime;

    PlayerInputActinos inputActions;
    //动态获取输入值
    Vector2 Axes => inputActions.Gameplay.Axes.ReadValue<Vector2>();
    //跳跃
    public bool Jump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    //停止跳跃
    public bool StopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    //判断是否开始移动
    public bool IsMove => Axisx != 0f;
    //x轴方向的值
    public float Axisx => Axes.x;
    //跳跃缓冲
    public bool HasJumpInputButter { get; set; }

    private void Awake()
    {
        inputActions = new PlayerInputActinos();
        waitJumpTime = new WaitForSeconds(jumpInputBufferTime);
    }
    //松开跳跃键时，取消跳跃缓冲
    private void OnEnable()
    {
        inputActions.Gameplay.Jump.canceled += delegate
        {
            HasJumpInputButter = false;
        };
    }
    /// <summary>
    /// 用于启用输入表的方法
    /// </summary>
    public void EnableGamePlayInputs()
    {
        inputActions.Gameplay.Enable();
        //禁用光标
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputButter = true;

        yield return waitJumpTime;

        HasJumpInputButter = false;
    }
    //禁用动作表
    public void DisableInputs()
    {
        inputActions.Gameplay.Disable();
    }
}
