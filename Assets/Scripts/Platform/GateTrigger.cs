using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField]
    AudioClip pickUpSFX;

    [SerializeField]
    ParticleSystem pickUpVFX;

    [SerializeField]
    VoidEventChannel gateTriggeredEventChannel;


    private void OnTriggerEnter(Collider other)
    {
        gateTriggeredEventChannel.Broadcast();
        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
        //Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
