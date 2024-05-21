using UnityEngine;
//这个类挂载在角色上，获取组件
//具体状态类中，通过这个类来取得某些组件并且实现状态转换
public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController playerController;

    PlayerInput playerInput;
    private void Awake()
    {
        //从自身开始遍历子物体获取第一个遇到的Animator
        animator = GetComponentInChildren<Animator>();

        playerController = GetComponent<PlayerController>();

        playerInput = GetComponent<PlayerInput>();
        //初始化状态字典长度
        stateTable = new System.Collections.Generic.Dictionary<System.Type, IState>(states.Length);

        //Todo：对每一个状态进行初始化
        foreach (PlayerState state in states)
        {
            state.Initialize(animator, playerController,playerInput, this);
            //在状态字典中，输入状态的类型就能获取到状态类
            stateTable.Add(state.GetType(), state);
        }

    }
    private void Start()
    {
        //游戏开始时为Idle
        SwitchOn(stateTable[(typeof(PlayerState_Idle))]);
    }
}
