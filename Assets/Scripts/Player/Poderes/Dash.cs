using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;//Para acceder al rigidbody del jugador
    private Animator animator;//Para acceder al animator
    public float velDash;//Velocidad del dash
    private float duracionDash;//Duracion del dash
    public float tiempoInicialDash;//Tiempo en el que inicia el dash
    private int direccion;//XD
    bool puedeDashear;

    //Inicializamos nuestras variables para acceder a los componentes
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        duracionDash = tiempoInicialDash;//El tiempo que dura el dash es el tiempo en el que inicia
    }

    void Update()
    {
        Dashing();
    }

    void Dashing()
    {
        

        if(direccion == 0)
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                direccion = 1;
                animator.SetBool("IsSprinting", true);
            }else if(Input.GetKey(KeyCode.LeftArrow))
            {
                direccion = 2;
                animator.SetBool("IsSprinting", true);
                
            }else if(Input.GetKey(KeyCode.UpArrow))
            {
                direccion = 3;
                animator.SetBool("IsSprinting", true);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                direccion = 4;
                animator.SetBool("IsSprinting", true);
            }
        }else
        {
            if(duracionDash <= 0)
            {
                direccion = 0;
                duracionDash = tiempoInicialDash;
                rb.velocity = Vector2.zero;
                animator.SetBool("IsSprinting", false);
            }
            else
            {
                duracionDash -= Time.deltaTime;
                
                switch(direccion)
                {
                    case 1:
                        rb.velocity = Vector2.right * velDash;
                        break;
                    case 2:
                        rb.velocity = Vector2.left * velDash;
                        break;
                    case 3:
                        rb.velocity = Vector2.up * velDash;
                        break;
                    case 4:
                        rb.velocity = Vector2.down * velDash;
                        break;
                }

            }
        }
    }

}
