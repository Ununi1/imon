using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
{
    [SerializeField]
    AudioClip pickUpSFX;

    [SerializeField]
    ParticleSystem pickUpVFX;

    [SerializeField]
    VoidEventChannel levelClearedEventChannel;

    private void OnTriggerEnter(Collider other)
    {
        levelClearedEventChannel.Broadcast();

        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
        //Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
