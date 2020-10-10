﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Body : MonoBehaviour
{
    [SerializeField]
    private Animator selfAnimator;
    [SerializeField]
    private Animator sackAnimator;
    [SerializeField]
    private Animator weaponAnimator;
    [SerializeField]
    private GameObject weaponThrow;
    [SerializeField]
    private Transform weaponPosition;
    [SerializeField] 
    private BoxCollider2D boxCollider2D;
    private static readonly int X = Animator.StringToHash("X");
    private static readonly int Y = Animator.StringToHash("Y");
    private static readonly int Move = Animator.StringToHash("Move");
    private static readonly int Attack = Animator.StringToHash("Attack");
    public bool attackBusy;
    public void DoAttackAnim(int attackType)
    {
        if (attackType == 3) weaponPosition.position = PlayerState.Instance.PlayerPosition;
        boxCollider2D.enabled = true;
        selfAnimator.SetInteger(Attack,attackType);
        weaponAnimator.SetInteger(Attack,attackType);
        sackAnimator.SetInteger(Attack,attackType);
    }

    public void DoMoveAnim(int x,int y,bool isMove)
    {
        if (x != -2 && y != -2)
        {
            selfAnimator.SetInteger(X,x);
            sackAnimator.SetInteger(X,x);
            weaponAnimator.SetInteger(X,x);
            selfAnimator.SetInteger(Y,y);
            sackAnimator.SetInteger(Y,y);
            weaponAnimator.SetInteger(Y,y);
        }
        selfAnimator.SetBool(Move,isMove);
        sackAnimator.SetBool(Move,isMove);
        weaponAnimator.SetBool(Move,isMove);
    }
    public void NotBusy()
    {
        attackBusy = false;
        boxCollider2D.enabled = false;
        selfAnimator.SetInteger(Attack,0);
        weaponAnimator.SetInteger(Attack,0);
        sackAnimator.SetInteger(Attack,0);
    }

    public void startThrowWeapon()
    {
        weaponThrow.SetActive(true);
    }
    public void stopThrowWeapon()
    {
//        weaponThrow.SetActive(false);
    }
}
