using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/EventChannles/VoidEventChannle",fileName = "VoidEventChannle_")]
//�¼�Ƶ�� 
public class VoidEventChannel : ScriptableObject
{
    event System.Action Delegate;

    //�㲥 
    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    //����
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    //�˶�
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
