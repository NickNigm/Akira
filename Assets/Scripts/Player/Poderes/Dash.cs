using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float velDash;
    private float duracionDash;
    public float tiempoInicialDash;
    private int direccion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        duracionDash = tiempoInicialDash;
    }

    // Update is called once per frame
    void Update()
    {
        if(direccion == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direccion = 1;
                animator.SetBool("IsSprinting", true);
            }else if(Input.GetKeyDown(KeyCode.RightArrow)){
                direccion = 2;
                animator.SetBool("IsSprinting", true);
            }else if(Input.GetKeyDown(KeyCode.UpArrow)){
                direccion = 3;
                animator.SetBool("IsSprinting", true);
            }else if(Input.GetKeyDown(KeyCode.DownArrow)){
                direccion = 4;
                animator.SetBool("IsSprinting", true);
            }
            
        }else{
            if(duracionDash <= 0 )
            {
                direccion = 0;
                duracionDash = tiempoInicialDash;
                rb.velocity = Vector2.zero;
                animator.SetBool("IsSprinting", false);
            }else{
                duracionDash -= Time.deltaTime;

                switch(direccion)
                {
                    case 1:
                        rb.position = rb.position + (Vector2.left * velDash);
                        break;
                    case 2:
                        rb.position = rb.position + (Vector2.right * velDash);
                        break;
                    case 3:
                        rb.position = rb.position + (Vector2.up * velDash);
                        break;
                    case 4:
                        rb.position = rb.position + (Vector2.down * velDash);
                        break;

                }

            }
        }   
        
    }
}
