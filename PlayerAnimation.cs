using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private void Awake() {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        physicsCheck=GetComponent<PhysicsCheck>();
    }
    private void Update(){
        SetAnimation();
    }
    public void SetAnimation(){
        anim.SetFloat("velocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY",rb.velocity.y);
        anim.SetBool("isGround",physicsCheck.isGround);
    }
}
