using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField]
    AudioClip pickUpSFX;

    [SerializeField]
    ParticleSystem pickUpVFX;

    MeshRenderer meshRenderer;

    Collider collider;

    WaitForSeconds waitTime;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();

        collider = GetComponentInChildren<Collider>();

        waitTime = new WaitForSeconds(3.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirJump = true;
            //关闭渲染器
            meshRenderer.enabled = false;
            //关闭碰撞体
            collider.enabled = false;
            //播放音效
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            //播放特效
            Instantiate(pickUpVFX, transform.position, transform.rotation);
            //开启协程，在几秒后调用宝石重生的方法
            StartCoroutine(nameof(ResetCoroutine));
        }
    }

    private void Reset()
    {
        //开启渲染器
        meshRenderer.enabled = true;
        //开启碰撞体
        collider.enabled = true;
    }
    //用于调用重生的协程
    IEnumerator ResetCoroutine()
    {
        yield return waitTime;

        Reset();
    }
}
