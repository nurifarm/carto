using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Chameleon : MonoBehaviour
{
    // *****************************************************
    // * variable
    // *****************************************************
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private Vector3 initialPos;
    private bool isTargetInRange = false;
    private bool isTargetInAttackRange = false;
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
        CheckTargetInRange();

        // Attack
        if (isTargetInAttackRange)
        {
            isInAction = true;
            anim.SetBool("isAttacking", true);
            StartCoroutine(CheckAnimationState());
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    
        if (!isInAction)
        {
            // Moving
            if (isTargetInRange)
            {
                anim.SetBool("isMoving", true);
                sr.flipX = (transform.position - target.position).x <= 0;
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
            }
            else if (!isTargetInRange && (transform.position != initialPos))
            {
                anim.SetBool("isMoving", true);
                sr.flipX = (transform.position - initialPos).x <= 0;
                transform.position = Vector2.MoveTowards(transform.position, initialPos, moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                anim.SetBool("isMoving", false);
                sr.flipX = false;
            }
        }   
    }

    void CheckTargetInRange()
    {
        float areaDistance = Vector2.Distance(initialPos, target.position);
        float attackDistance = Vector2.Distance(transform.position, target.position);

        if (areaDistance < maxRange)
        {
            isTargetInRange = true;
        }
        else
        {
            isTargetInRange = false;
        }

        if (attackDistance < attackRange)
        {
            isTargetInAttackRange = true;
        }
        else
        {
            isTargetInAttackRange = false;
        }
    }

    IEnumerator CheckAnimationState()
    {
        
        while (anim.GetCurrentAnimatorStateInfo(0)
        .normalizedTime < 1.0f)
        {
            //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }
        
        //애니메이션 완료 후 실행되는 부분
        isInAction = false;
    }

}
