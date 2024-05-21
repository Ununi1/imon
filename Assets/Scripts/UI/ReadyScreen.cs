using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField]
    VoidEventChannel startEventChannel;
    [SerializeField]
    Animator UIanimator;


    float stateStartTime;

    float StateDuration => Time.time - stateStartTime;

    private void Awake()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
    private void OnEnable()
    {
        startEventChannel.AddListener(AnimationEnd);
        stateStartTime = Time.time;
    }
    private void OnDisable()
    {
        startEventChannel.RemoveListener(AnimationEnd);
    }

    void AnimationEnd()
    {
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;

    }
    
    private void Update()
    {
        if (StateDuration>=UIanimator.GetCurrentAnimatorStateInfo(0).length)
        {
            startEventChannel.Broadcast();
        }
    }
}
