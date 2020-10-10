using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 torwadsPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool start=true;
    private bool isBack=false;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            torwadsPosition=getTowardsPosition(rb.position);
            start = false;
        }
        transform.Rotate(0, 0, 800 * Time.deltaTime);
        if (isBack)
        {
            rb.position = Vector2.MoveTowards(rb.position,PlayerState.Instance.PlayerPosition, 0.2f);
            if (rb.position == PlayerState.Instance.PlayerPosition)
            {
                isBack = false;
                start = true;
                gameObject.SetActive(false);
            }
        }
        else
        {
            rb.position=Vector2.MoveTowards(rb.position,torwadsPosition,0.2f);
            if (rb.position == torwadsPosition)
            {
                isBack = true;
            }
        }
    }

    private Vector2 MousePosition()
    {
        Vector2 vector2 = rb.position;
        Vector2 vector2Temp=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vector2 = vector2Temp - vector2;
        return vector2;
    }
    public Vector2 getTowardsPosition(Vector2 currentPosition)
    {
        Vector2 vector2 = MousePosition();
        double c = Math.Atan2(vector2.y, vector2.x);
        return new Vector2((float) (5*Math.Cos(c)),(float) (5*Math.Sin(c)));
    }
}
