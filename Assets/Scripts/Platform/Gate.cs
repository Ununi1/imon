using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    GateTrigger gateTrigger;
    [SerializeField]
    VoidEventChannel gateTriggeredEventChannel;
    void Open()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        gateTriggeredEventChannel.AddListener(Open);
    }
    private void OnDisable()
    {
        gateTriggeredEventChannel.RemoveListener(Open);
    }
}
