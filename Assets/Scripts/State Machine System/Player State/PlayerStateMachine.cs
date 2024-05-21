using UnityEngine;
//���������ڽ�ɫ�ϣ���ȡ���
//����״̬���У�ͨ���������ȡ��ĳЩ�������ʵ��״̬ת��
public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController playerController;

    PlayerInput playerInput;
    private void Awake()
    {
        //������ʼ�����������ȡ��һ��������Animator
        animator = GetComponentInChildren<Animator>();

        playerController = GetComponent<PlayerController>();

        playerInput = GetComponent<PlayerInput>();
        //��ʼ��״̬�ֵ䳤��
        stateTable = new System.Collections.Generic.Dictionary<System.Type, IState>(states.Length);

        //Todo����ÿһ��״̬���г�ʼ��
        foreach (PlayerState state in states)
        {
            state.Initialize(animator, playerController,playerInput, this);
            //��״̬�ֵ��У�����״̬�����;��ܻ�ȡ��״̬��
            stateTable.Add(state.GetType(), state);
        }

    }
    private void Start()
    {
        //��Ϸ��ʼʱΪIdle
        SwitchOn(stateTable[(typeof(PlayerState_Idle))]);
    }
}
