using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public bool EnemIsAttacking = false;
    public float vel;
    public float stopDistance;
    private Transform player;
    public SpriteRenderer sr;
    Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        transform.position = Vector2.MoveTowards(transform.position, player.position, vel * Time.deltaTime);

        if(transform.position.x > player.position.x)
        sr.flipX = true;
        else
        sr.flipX = false;

        if(EnemIsAttacking)
            animator.SetBool("EnemIsAttacking", true);
        else
            animator.SetBool("EnemIsAttacking", false);
    }
}
