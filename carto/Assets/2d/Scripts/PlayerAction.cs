using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField, Range(0f, 100f)]
    private float moveSpeed = 5f;

    float h;
    float v;


    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(out rb))
            rb = gameObject.AddComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // == MOVE ==
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate() 
    {
        transform.Translate(new Vector2(h, v) * Time.fixedDeltaTime * moveSpeed);
        rb.velocity = new Vector2(h, v);

    }
}
