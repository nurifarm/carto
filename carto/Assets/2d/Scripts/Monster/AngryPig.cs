using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class AngryPig : MonoBehaviour
{
    // *****************************************************
    // * variable
    // *****************************************************
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private Vector2 initialPos;
    private bool isTargetInRange = false;
    private bool isAttackRange = false;

    private bool isInAction = false;
    
    private float maxRange = 4.0f;
    private float moveSpeed = 1.0f;

    // *****************************************************
    // * target variable
    // *****************************************************
    private Transform target;

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

        initialPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        CheckObjectInArea();
    }

    void FixedUpdate()
    {
        if (isInAction)
        {
            // TODO: 공격 및 다른 행동 
        }
        else
        {
            if (isTargetInRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, initialPos, moveSpeed * Time.fixedDeltaTime);
            }
        }
        
    }

    void CheckObjectInArea()
    {
        float distance = Vector2.Distance(initialPos, target.position);

        if (distance < maxRange)
        {
            isTargetInRange = true;
        }
        else
        {
            isTargetInRange = false;
        }
    }



}
