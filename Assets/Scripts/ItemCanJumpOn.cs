using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanJumpOn : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Renderer renderer;
    private void Awake()
    {
        boxCollider2D=GetComponent<BoxCollider2D>();
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("跳上去:"+PlayerState.Instance.IsJump);
        if (PlayerState.Instance.IsJump&&other.gameObject.tag.Equals("Player"))
        {
            
            boxCollider2D.isTrigger = true;
            renderer.sortingLayerName = "Background";
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!PlayerState.Instance.IsJump&&other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("跳出去");
            boxCollider2D.isTrigger = false;
            renderer.sortingLayerName = "Itemground";
        }
    }
}
