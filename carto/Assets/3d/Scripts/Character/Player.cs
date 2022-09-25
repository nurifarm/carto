using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private bool isMoving = false;
    private bool isJumpRequired = false;

    [SerializeField, Range(0f, 100f)]
    private float moveSpeed = 5f;

    [SerializeField, Range(0f, 100f)]
    private float jumpForce = 5f;

    private void Start()
    {
        if (!TryGetComponent(out rb))
            rb = gameObject.AddComponent<Rigidbody>();
    }

    private void Update()
    {
        // == MOVE ==
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        isMoving = (h != 0f || v != 0f);

        if (isMoving)
        {
            moveDir = transform.forward * v + transform.right * h;
            moveDir.Normalize();
        }

        // == JUMP ==
        if (Input.GetKeyDown(KeyCode.Space))
            isJumpRequired = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 moveOffset = moveDir * (moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + moveOffset);
        }

        if (isJumpRequired)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.VelocityChange);
            isJumpRequired = false;
        }
    }
}