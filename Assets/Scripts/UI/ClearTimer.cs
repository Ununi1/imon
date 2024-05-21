using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimer : MonoBehaviour
{
    [SerializeField]
    Text timer;

    float clearTime;

    bool stop=true;
    [SerializeField]
    VoidEventChannel levelStartedEventChannel;
    [SerializeField]
    VoidEventChannel levelClearEventChannel;
    [SerializeField]
    StringEventChannel timeEventChannel;
    [SerializeField]
    VoidEventChannel falseEventChannel;
    private void OnEnable()
    {
        levelStartedEventChannel.AddListener(LevelStart);
        levelClearEventChannel.AddListener(LevelClear);
        falseEventChannel.AddListener(HideUI);
    }

    private void OnDisable()
    {
        levelStartedEventChannel.RemoveListener(LevelStart);
        levelClearEventChannel.RemoveListener(LevelClear);
        falseEventChannel.RemoveListener(HideUI);
    }

    private void LevelStart()
    {
        stop = false;
    }
    private void LevelClear()
    {
        
        timeEventChannel.Broadcast(timer.text);
        HideUI();
    }

    private void FixedUpdate()
    {
        if (stop)
        {
            return;
        }

        clearTime += Time.fixedDeltaTime;
        timer.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    void HideUI()
    {
        stop = true;
        GetComponent<Canvas>().enabled = false;
    }
}
