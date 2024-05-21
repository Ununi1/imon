using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField]
    float dectionRadius = 0.1f;
    [SerializeField]
    LayerMask groundLayer;
    //���ڼ���Ƿ����غϵ���ײ������
    Collider[] colliders = new Collider[1];
    public bool IsGround
    {
        get
        {
            //���ط�Χ�ڵ���ײ������������Ƿ���������غ�
            return Physics.OverlapSphereNonAlloc(transform.position, dectionRadius, colliders, groundLayer) != 0;
        }
    }
    //������ײ���ķ�Χ
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dectionRadius);
    }
}
