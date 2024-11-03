using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 bottomOffset;
    public bool isGround;
    public int sumJump;
    public float checkRadius;
    public LayerMask groundLayer;
    private void Update() {
        Check();
    }
    public void Check(){
        //检测地面
        isGround=Physics2D.OverlapCircle((Vector2)transform.position+bottomOffset,checkRadius,groundLayer);
        if(isGround) sumJump=2;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere((Vector2)transform.position+bottomOffset,checkRadius);
    }
}
