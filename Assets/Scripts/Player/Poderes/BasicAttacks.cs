using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttacks : MonoBehaviour
{
    private Animator animator;
    public AudioSource sonido;
    public AudioClip espada1;
    public AudioClip espada2;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sonido = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        ataque1();
        ataque2();
    }
    public float tiempo = 0.5f;
    public float tiempo2 = 0.5f;
    public bool atacando = false;
    public bool atacando2 = false;
    void ataque1()
    {
        if(Input.GetMouseButton(0)){
            atacando = true;
            sonido.clip = espada1;
            sonido.Play();
        }
        
        if(atacando){
            tiempo -= Time.deltaTime;
            animator.SetBool("IsAttack1", true);
        }

        if(tiempo <= 0){
            animator.SetBool("IsAttack1", false);
            tiempo = 0.5f;
            atacando = false;
        }
    }

    void ataque2()
    {
        if(Input.GetMouseButton(1)){
            atacando2 = true;
            sonido.clip = espada2;
            sonido.Play();
        }
        
        if(atacando2){
            tiempo2 -= Time.deltaTime;
            animator.SetBool("IsAttack2", true);
        }

        if(tiempo2 <= 0){
            animator.SetBool("IsAttack2", false);
            tiempo2 = 0.5f;
            atacando2 = false;
        }
    }
}
