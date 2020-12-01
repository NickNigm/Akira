using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Agregamos nuestros componentes esenciales*/
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMvm : MonoBehaviour
{

    /*Delimitamos el area en Y por las que nuestro personaje puede caminar*/
    static Vector2 LimiteY = new Vector2(-0.92f, 1.225f);

    /*[SerializeField]
    float velVert;//Velocidad de movimiento Vertical
    [SerializeField]
    float velHorz;//Velocidad de movimiento Horizontal
*/
    Rigidbody2D rb;//Rigidbody del personaje
    SpriteRenderer sr;//Spriterenderer del personaje
    Animator animator;//Animator

    /*Inicializamos nuestras variables*/
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    //Llamamos nuestro metodo de movimiento para que se ejecute cada frame
    void Update()
    {
        Mvm();

    }

    Vector2 ctrl;//Aqui guardamos los controles de movimiento

    /*Movimiento del personaje*/
    void Mvm()
    {
        /*Asiganmos y guardamos los controles de
        movimiento en nuestra variable de control*/
        ctrl = new Vector2(Input.GetAxisRaw("Horizontal"), 
        Input.GetAxisRaw("Vertical"));

        //Giramos nuestro sprite dependiendo de la direccion en la que nos movamos
        if(ctrl.x !=0)
            sr.flipX = ctrl.x < 0;

        //Comienza la animacion de correr en cuanto se detecta que nos movemos
        animator.SetBool("IsRunning", ctrl.magnitude !=0);
        
        //Velocidad con la que nos movemos
        //rb.velocity = new Vector2(ctrl.x * velHorz, ctrl.y * velVert);
        
        //Activamos nuestros limites de movimiento en el espacio Y
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimiteY.x, LimiteY.y)
        , transform.position.z);

    }

}
