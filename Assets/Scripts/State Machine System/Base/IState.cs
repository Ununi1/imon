public interface IState 
{
    /// <summary>
    /// 状态的进入
    /// </summary>
    void Enter();

    /// <summary>
    /// 状态的退出
    /// </summary>
    void Exit();

    /// <summary>
    /// 状态的逻辑更新
    /// </summary>
    void LogicUpdate();

    /// <summary>
    /// 物理更新
    /// </summary>
    void PhysicUpdate();
}
