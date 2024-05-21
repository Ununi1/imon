using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]
    VoidEventChannel levelClearedEventChannel;
    [SerializeField]
    Button nextLevlButton;
    [SerializeField]
    Text timeText;
    [SerializeField]
    StringEventChannel timeEventChannel;
    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(ShowUI);
        timeEventChannel.AddListener(SetTimeText);
        nextLevlButton.onClick.AddListener(SenneLoader.LoadNextScene);
    }

    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(ShowUI);
        nextLevlButton.onClick.RemoveListener(SenneLoader.LoadNextScene);
    }

    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
    private void SetTimeText(string obj)
    {
        timeText.text = obj;
    }
}
