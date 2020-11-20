using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Mover();
        salto();
        if(comprobandoSalto) compararPosicion();
    }

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;
    bool puedeSaltar = true, comprobandoSalto = false;
    public float fuerzaSalto;
    public float posInicialSalto;
    float velocidad = 5f;

    private void Mover() {

        
        
        float posX = velocidad * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(posX, 0, 0);
        if( posX != 0 ) sr.flipX = posX < 0;
        if(puedeSaltar){
            animator.SetBool("IsRunning",
            Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D));
            float posY = velocidad * Time.deltaTime * Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(0, posY, 0);
        }
    }

    void salto(){
        bool saltando = Input.GetKey(KeyCode.Space);
        if(saltando && puedeSaltar){
            velocidad = 2f;
            posInicialSalto = transform.position.y;
            rb2d.gravityScale = 1;
            rb2d.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar = false;
            comprobandoSalto = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void compararPosicion(){
        if(posInicialSalto > transform.position.y){
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2d.gravityScale = 0;
            puedeSaltar = true;
            comprobandoSalto = false;
            velocidad = 5f;
            animator.SetBool("IsJumping", false);
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}