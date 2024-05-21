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
            //�ر���Ⱦ��
            meshRenderer.enabled = false;
            //�ر���ײ��
            collider.enabled = false;
            //������Ч
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            //������Ч
            Instantiate(pickUpVFX, transform.position, transform.rotation);
            //����Э�̣��ڼ������ñ�ʯ�����ķ���
            StartCoroutine(nameof(ResetCoroutine));
        }
    }

    private void Reset()
    {
        //������Ⱦ��
        meshRenderer.enabled = true;
        //������ײ��
        collider.enabled = true;
    }
    //���ڵ���������Э��
    IEnumerator ResetCoroutine()
    {
        yield return waitTime;

        Reset();
    }
}
