using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    [Header("基本参数")]
    public float speed;
    public float jumpForce;
    
    private void Awake() {
        physicsCheck=GetComponent<PhysicsCheck>();
        inputControl = new PlayerInputControl();
        rb=GetComponent<Rigidbody2D>();

        //+=表示注册,把该函数方法添加到该案件按下的那一刻。
        inputControl.Gameplay.Jump.started+=Jump;

        //潜行
        inputControl.Gameplay.Shift.started+=Shift;
    }

    private void OnEnable() {
        inputControl.Enable();
    }

    private void OnDisable() {
        inputControl.Disable();
    }

    private void Update() {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }
    
    private void FixedUpdate() {
        Move();    
    }
    
    // private void OnTriggerStay2D(Collider2D other) {
    //     Debug.Log(other.name);
    // }
    
    public void Move(){
        //rb的速度，速度×时间调整×X坐标值，y值保持原先不变
        rb.velocity=new Vector2(speed*Time.deltaTime*inputDirection.x,rb.velocity.y);
        //人物翻转
        int faceDir =(int) transform.localScale.x;
        if(inputDirection.x>0) faceDir=1;
        if(inputDirection.x<0) faceDir=-1;
        transform.localScale=new Vector3(faceDir,1,1);
    } 
    private void Shift(InputAction.CallbackContext context)
    {
        //Debug.Log("FUCK");
        //rb.velocity=new Vector2(rb.velocity.x/3,rb.velocity.y);
    }
    

    
    private void Jump(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGround){
            physicsCheck.sumJump--;
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
        if(physicsCheck.isGround==false){
            if(physicsCheck.sumJump>0){
                rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
                physicsCheck.sumJump=0;
            }
        }
    }
    
}
