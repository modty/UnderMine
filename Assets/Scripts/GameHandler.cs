using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private SpriteAnimator spriteAnimator;

    private void Start()
    {
        spriteAnimator.OnAnimationLooped += SpriteAnimator_OnAnimationLooped;
        spriteAnimator.OnAnimationLoopedFirstTime += SpriteAnimator_OnAnimationLoopedFirstTime;
    }

    
    private void SpriteAnimator_OnAnimationLooped(object sender, EventArgs e)
    {
//        Debug.Log("循环");

    }

    private float timeTest;
    private void SpriteAnimator_OnAnimationLoopedFirstTime(object sender, EventArgs e)
    {
        if (isBusy)
        {
//            Debug.Log("攻击完毕");
            isBusy = false;
        }
    }


    private void Update()
    {
        if (!isBusy)
        {
            HandleAttack();
        }
        if (!isBusy)
        {
            HandleMovement();
        }
//        if (Input.GetKey(KeyCode.Mouse0))
//        {
//            spriteAnimator.PlayAnimationCPeonFem(CPeonFem.SwingRight,.05f,1,0);
//        }else if (Input.GetKey(KeyCode.Mouse1))
//        {
//            spriteAnimator.PlayAnimationCPeonFem(CPeonFem.SwingRight,.05f,1,0);
//        }
//        else
//        {
//            spriteAnimator.PlayAnimationCPeonFem(CPeonFem.IdleToRight,.1f,1,0);
//        }
//        if(action) return;
//        if (Input.GetKey(KeyCode.D))
//        {
//            spriteAnimator.Move(CPeonFem.WalkRight,.1f,1);
//        }
//        else if(Input.GetKey(KeyCode.W))
//        {
//            spriteAnimator.Move(CPeonFem.WalkTop,.1f,1);
//        }
//        else if (Input.GetKey(KeyCode.S))
//        {
//            spriteAnimator.Move(CPeonFem.WalkBottom,.1f,1);
//        }
//        else if(Input.GetKey(KeyCode.A))
//        {
//            spriteAnimator.Move(CPeonFem.WalkLeft,.1f,1);
//        }
//        else
//        {
//            spriteAnimator.Move(CPeonFem.IdleToBottom,.1f,-1);
//        }

    }
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private bool isBusy;
    private void HandleAttack()
    {
        int mouse = 0;
        if (Input.GetKeyDown(KeyCode.Mouse0)) mouse = 1;
        else if (Input.GetKeyDown(KeyCode.Mouse1)) mouse = 2;
        if (mouse != 0&&!isBusy)
        {
//            Debug.Log("攻击");
            Vector3 vector3 = Input.mousePosition;
            spriteAnimator.Attack(mouse,vector3);
            isBusy = true;
        }
    }
    
    private void HandleMovement() {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveX = +1f;
        }
        moveDir = new Vector3(moveX, moveY).normalized;
        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle) {
            spriteAnimator.Idle(lastMoveDir);
        } else {
            spriteAnimator.Move(moveDir);
            lastMoveDir = moveDir;
            
        }
    }
}
