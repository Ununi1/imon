using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneParameterEventChannel<T> : ScriptableObject
{
    event System.Action<T> Delegate;

    //¹ã²¥ 
    public void Broadcast(T obj)
    {
        Delegate?.Invoke(obj);
    }
    //¶©ÔÄ
    public void AddListener(System.Action<T> action)
    {
        Delegate += action;
    }
    //ÍË¶©
    public void RemoveListener(System.Action<T> action)
    {
        Delegate -= action;
    }
}
