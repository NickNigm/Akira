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

    bool puedeDash = true;

    //Inicializamos nuestras variables para acceder a los componentes
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        duracionDash = tiempoInicialDash;//El tiempo que dura el dash es el tiempo en el que inicia
    }

    void Update()
    {
        fDash();
    }

    void direccionDash(int dir, Vector2 vector){
        direccion = dir;
        animator.SetBool("IsSprinting", true);
        /*if(duracionDash > 0){
            duracionDash -= Time.deltaTime;
            if(direccion!=0) rb.position += vector * velDash; 
        } */
    }

    void fDash(){
        /*Dash
        Delimitamos el valor de la direccion de acuerdo a la tecla que presionemos*/
        if(direccion == 0)
        {
            
            /*Se presiona izquierda, derecha, arriba, abajo. 
            Direccion = 1, 2, 3, 4.
            Activamos nuestra animacion de sprint*/
            if(Input.GetKeyDown(KeyCode.LeftArrow)) direccionDash(1, Vector2.left);
            if(Input.GetKeyDown(KeyCode.RightArrow)) direccionDash(2, Vector2.right);
            if(Input.GetKeyDown(KeyCode.UpArrow)) direccionDash(3, Vector2.up);
            if(Input.GetKeyDown(KeyCode.DownArrow)) direccionDash(4, Vector2.down);
            
        }else{
            /*Comprobamos que estamos dasheando.
            Si nuestra duracion del dash es mayor a 0 quiere decir que si.*/
            if(duracionDash <= 0 )
            {
                //Si ya no dasheamos
                direccion = 0;//Direccion regresa a 0
                duracionDash = tiempoInicialDash;//Reiniciamos la duracion del dash
                rb.velocity = Vector2.zero;//Velocidad se establece en 0
                animator.SetBool("IsSprinting", false);//La animacion de sprinting se desactiva
            }else{
                //Si seguimos dasheando reducimos el tiempo del dash 
                duracionDash -= Time.deltaTime;

                //El lugar a donde nos reposicionaremos dependiendo del valor de nuestra direccion
                switch(direccion)
                {
                    case 1:
                        rb.position = rb.position + (Vector2.left * velDash);//Modificamos nuestra direccion
                        //sumandole la direccion por la velocidad con la que se efectuara esta
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