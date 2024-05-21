using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField]
    VoidEventChannel playerDefeatedEventChannel;
    [SerializeField]
    AudioClip[] audioClip;
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Button quitButton;
    private void OnEnable()
    {
        playerDefeatedEventChannel.AddListener(ShowUI);
        retryButton.onClick.AddListener(SenneLoader.ReloadScene);
        quitButton.onClick.AddListener(SenneLoader.QuitGame);
    }
    private void OnDisable()
    {
        playerDefeatedEventChannel.RemoveListener(ShowUI);
        retryButton.onClick.RemoveListener(SenneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SenneLoader.QuitGame);
    }

    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        AudioClip audio = audioClip[Random.Range(0,audioClip.Length)];
        SoundEffectsPlayer.AudioSource.PlayOneShot(audio);

        Cursor.lockState = CursorLockMode.None;
    }
}
