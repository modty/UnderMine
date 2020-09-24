using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAction : MonoBehaviour
{

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Weapon"))
        {
            Debug.Log("被攻击");
        }
    }
}
