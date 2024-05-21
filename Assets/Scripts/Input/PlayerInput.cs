using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �����ר����������Input system������ 
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float jumpInputBufferTime = 0.3f;

    WaitForSeconds waitJumpTime;

    PlayerInputActinos inputActions;
    //��̬��ȡ����ֵ
    Vector2 Axes => inputActions.Gameplay.Axes.ReadValue<Vector2>();
    //��Ծ
    public bool Jump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    //ֹͣ��Ծ
    public bool StopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    //�ж��Ƿ�ʼ�ƶ�
    public bool IsMove => Axisx != 0f;
    //x�᷽���ֵ
    public float Axisx => Axes.x;
    //��Ծ����
    public bool HasJumpInputButter { get; set; }

    private void Awake()
    {
        inputActions = new PlayerInputActinos();
        waitJumpTime = new WaitForSeconds(jumpInputBufferTime);
    }
    //�ɿ���Ծ��ʱ��ȡ����Ծ����
    private void OnEnable()
    {
        inputActions.Gameplay.Jump.canceled += delegate
        {
            HasJumpInputButter = false;
        };
    }
    /// <summary>
    /// �������������ķ���
    /// </summary>
    public void EnableGamePlayInputs()
    {
        inputActions.Gameplay.Enable();
        //���ù��
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
    //���ö�����
    public void DisableInputs()
    {
        inputActions.Gameplay.Disable();
    }
}
