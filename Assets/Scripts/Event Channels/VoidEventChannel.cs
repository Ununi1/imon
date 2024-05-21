using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/EventChannles/VoidEventChannle",fileName = "VoidEventChannle_")]
//事件频道 
public class VoidEventChannel : ScriptableObject
{
    event System.Action Delegate;

    //广播 
    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    //订阅
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    //退订
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
