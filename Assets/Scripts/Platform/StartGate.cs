using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    [SerializeField]
    VoidEventChannel startEventChannel;
    [SerializeField]
    AudioClip audioClip;
    private void OnEnable()
    {
        startEventChannel.AddListener(SrartGeta);
    }
    private void OnDisable()
    {
        startEventChannel.RemoveListener(SrartGeta);
    }
    
    void SrartGeta()
    {
        SoundEffectsPlayer.AudioSource.PlayOneShot(audioClip);

        Destroy(gameObject);
    }
}
