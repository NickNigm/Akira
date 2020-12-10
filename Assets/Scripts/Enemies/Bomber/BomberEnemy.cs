using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemy : MonoBehaviour
{
    public float vel;
    public float stopDistance;
    public float retreatDistance;
    private float tiempreEntreLazamientos;
    public float empezarTiempoEntreLanzamientos;
    public GameObject bomba;
    private Transform player;
    private SpriteRenderer sr;
    Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tiempreEntreLazamientos = empezarTiempoEntreLanzamientos;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, vel * Time.deltaTime);
            animator.SetBool("BomberIsThrowing", false);
            animator.SetBool("BomberIsRunning", true);
        }
        else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            animator.SetBool("BomberIsRunning", false);
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -vel * Time.deltaTime);
            animator.SetBool("BomberIsThrowing", false);
            animator.SetBool("BomberIsRunning", true);
        }

        if(tiempreEntreLazamientos <= 0)
        {
            Instantiate(bomba, transform.position, Quaternion.identity);
            tiempreEntreLazamientos = empezarTiempoEntreLanzamientos;
        }
        else {
            tiempreEntreLazamientos -= Time.deltaTime;
        }

        if(tiempreEntreLazamientos <= 0)
            {
                Instantiate(bomba, transform.position, Quaternion.identity);
                tiempreEntreLazamientos = empezarTiempoEntreLanzamientos;
                
            }
            else {
                tiempreEntreLazamientos -= Time.deltaTime;
            }

        if(transform.position.x > player.position.x)
        sr.flipX = true;
        else
        sr.flipX = false;
    }
}
