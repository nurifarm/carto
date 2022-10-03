using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerAction : MonoBehaviour
{

    // *****************************************************
    // * variable
    // *****************************************************
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    
    private Vector2 moveDir;
    private bool isMoving = false;

    //[SerializeField, Range(0.0f, 100.0f)]
    private float moveSpeed = 3.0f;

    void Start()
    {
        if (!TryGetComponent(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        if (!TryGetComponent(out sr))
        {
            sr = gameObject.AddComponent<SpriteRenderer>();
        }

        if (!TryGetComponent(out anim))
        {
            anim = gameObject.AddComponent<Animator>();
        }
        
    }

    void Update()
    {
        // == MOVE ==
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        isMoving = (h != 0f || v != 0f);

        if (isMoving)
        {
            moveDir = transform.up * v + transform.right * h;
            moveDir.Normalize();

            // Direction Sprite
            sr.flipX = Input.GetAxisRaw("Horizontal") == -1;

        }

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(PopupManager.Instance.IsActive("DialoguePopup"))
			{
				PopupManager.Instance.Hide();
			} else
			{
				PopupManager.Instance.Show("DialoguePopup");
			}
		}

    }
    
    void FixedUpdate() 
    {
        if (isMoving)
        {
            Vector2 moveOffset = moveDir * (moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + moveOffset);

            // Moving Animation
            anim.SetBool("isMoving", true);
        }
        else
        {
            // idle Animation
            anim.SetBool("isMoving", false);
        }

    }
}
