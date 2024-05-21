using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField]
    float dectionRadius = 0.1f;
    [SerializeField]
    LayerMask groundLayer;
    //用于检测是否有重合的碰撞体数组
    Collider[] colliders = new Collider[1];
    public bool IsGround
    {
        get
        {
            //返回范围内的碰撞器数量来检测是否与地面有重合
            return Physics.OverlapSphereNonAlloc(transform.position, dectionRadius, colliders, groundLayer) != 0;
        }
    }
    //绘制碰撞检测的范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dectionRadius);
    }
}
