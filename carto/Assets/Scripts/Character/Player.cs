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
    private float hRot;

    // 입력 상태
    private bool isCursorLocked = false;
    private bool isMoving       = false;
    private bool isRotating     = false;
    private bool isJumpRequired = false;

    // 키 설정
    [SF] private KeyCode cursorLockKey = KeyCode.LeftAlt;
    [SF] private KeyCode jumpKey = KeyCode.Space;

    // 계수 설정
    [SF, Range(0f, 100f)] private float moveSpeed   = 10f;
    [SF, Range(0f, 200f)] private float rotateSpeed = 100f;
    [SF, Range(0f, 100f)] private float jumpForce   = 5f;

    private void Start()
    {
        if (!TryGetComponent(out rb))
            rb = gameObject.AddComponent<Rigidbody>();

        rb.freezeRotation = true; // 다른 강체에 부딪혔을 때 회전하지 않도록 설정한다.
        isCursorLocked = false;   // 마우스 커서 초기 상태 : 커서 표시 & 미잠금

        // FrameRate가 너무 높으면 FixedUpdate에 의한 회전이 부자연스러워진다.
        // 추후, targetFrameRate 설정 코드는 여기서 제거하고 매니저 클래스로 옮기는 것이 좋다.
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        ToggleCursorLock();
        Move();
        Rotate();
        Jump();
    }

    private void ToggleCursorLock()
    {
        // NOTE : cursorLockKey는 토글 키로 사용되며, 커서 잠금 및 표시 상태를 전환한다.
        if (Input.GetKeyDown(cursorLockKey))
        {
            isCursorLocked = !isCursorLocked;
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;
        }
    }

    private void Move()
    {
        // NOTE : GetAxis()를 사용할 경우, 정지 시 조금씩 미끄러지며 멈춘다.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        isMoving = (h != 0f || v != 0f);

        if (isMoving)
        {
            moveDir = transform.TransformDirection(new Vector3(h, 0f, v));
            moveDir.Normalize();
        }
    }

    private void Rotate()
    {
        // NOTE 1 : "Mouse X"에 대한 GetAxis(), GetAxisRaw()는 차이가 없다.
        // NOTE 2 : 커서 잠금 및 미표시 상태에서만 회전하도록 한다.
        if (isCursorLocked)
        {
            hRot = Input.GetAxis("Mouse X");
            isRotating = (hRot != 0f);
        }
        else
            isRotating = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey))
            isJumpRequired = true;
    }

    private void FixedUpdate()
    {
        float fixedDeltaTime = Time.fixedDeltaTime;

        if (isMoving)
        {
            Vector3 moveOffset = moveDir * (moveSpeed * fixedDeltaTime);
            rb.MovePosition(rb.position + moveOffset);
        }

        if (isRotating)
        {
            float rotAngle = hRot * rotateSpeed * fixedDeltaTime;
            rb.rotation = Quaternion.AngleAxis(rotAngle, Vector3.up) * rb.rotation; // 좌우 회전
        }

        if (isJumpRequired)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.VelocityChange);
            isJumpRequired = false;
        }
    }
}