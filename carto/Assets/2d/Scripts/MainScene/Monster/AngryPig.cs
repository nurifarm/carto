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

    private Vector3 initialPos;

    private State state = State.IDLE;
    private bool isInAction = false;

    private float maxRange = 4.0f;
    private float attackRange = 1.0f;
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
        
    }

    void FixedUpdate()
    {
        
        if (!isInAction)
        {
            CheckState();
        
            switch (state)
            {
                case State.MOVE2ORIGIN:
                    anim.SetBool("isMoving", true);
                    sr.flipX = (transform.position - initialPos).x <= 0;
                    transform.position = Vector2.MoveTowards(transform.position, initialPos, moveSpeed * Time.fixedDeltaTime);
                    break;

                case State.MOVE2TARGET:
                    anim.SetBool("isMoving", true);
                    sr.flipX = (transform.position - target.position).x <= 0;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                    break;

                // case State.ATTACK:
                //     anim.SetTrigger("isAttacking");
                //     StartCoroutine(CheckAnimationState("Attack"));
                //     break;

                case State.IDLE:
                    anim.SetBool("isMoving", false);
                    sr.flipX = false;
                    break;

                default:
                    break;
            }
        }
    }

    void CheckState()
    {
        float orgin2target = Vector2.Distance(initialPos, target.position);
        float object2target = Vector2.Distance(transform.position, target.position);

        if (orgin2target <= maxRange)
        {
            if (object2target <= attackRange)
            {
                state = State.ATTACK;
                return;
            }

			state = State.MOVE2TARGET;
            return;
        }
        else if (transform.position != initialPos)
        {
			state = State.MOVE2ORIGIN;
            return;
        }
        else
        {
            state = State.IDLE;
            return;
        }

    }

    IEnumerator CheckAnimationState(string actionName)
    {
        
        while (!anim.GetCurrentAnimatorStateInfo(0)
        .IsName(actionName)) 
        { 
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime < 1.0f)
        {
            //애니메이션 재생 중 실행되는 부분
            isInAction = true;         
            yield return null;
        }
        
        //애니메이션 완료 후 실행되는 부분
        isInAction = false;
    }

}
