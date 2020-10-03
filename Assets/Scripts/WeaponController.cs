using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 800 * Time.deltaTime);
        rb.position = rb.position + 5f * Time.deltaTime * Vector2.up;
    }
}
