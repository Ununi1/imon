public interface IState 
{
    /// <summary>
    /// ״̬�Ľ���
    /// </summary>
    void Enter();

    /// <summary>
    /// ״̬���˳�
    /// </summary>
    void Exit();

    /// <summary>
    /// ״̬���߼�����
    /// </summary>
    void LogicUpdate();

    /// <summary>
    /// �������
    /// </summary>
    void PhysicUpdate();
}
