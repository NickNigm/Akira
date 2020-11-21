using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    //Componentes del objeto
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    //Variables para limitar el salto a 1 y comprobar si se debe medir la distancia del salto
    bool puedeSaltar = true, comprobandoSalto = false;
    public float fuerzaSalto;
    public float posInicialSalto; //Guarda la posicion en Y del objeto antes de saltar
    float velocidad = 5f; //Velocidad de movimiento

    //Iniciamos los componenetes
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Mover();
        salto(); 
        if(comprobandoSalto) compararPosicion(); //Comprueba el la distancia entre el punto de salto y la pocición actual
    }

    private void Mover() {
        float posX = velocidad * Time.deltaTime * Input.GetAxisRaw("Horizontal"); //asigna el movimiento del eje X a posX
        transform.position += new Vector3(posX, 0, 0); // PosX agrega el movimiento en el eje X
        
        if( posX != 0 ) sr.flipX = posX < 0; //Inivter el sprite al moverse atras en el eje X

        //Comprueba si el objeto puede saltar
        if(puedeSaltar){
            //Cambia la animacion a Correr si se preciona A o D
            animator.SetBool("IsRunning", Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D));
            float posY = velocidad * Time.deltaTime * Input.GetAxisRaw("Vertical"); //asigna el movimiento del eje Y a posY
            transform.position += new Vector3(0, posY, 0);  // PosY agrega el movimiento en el eje Y
        }
    }

    void salto(){
        bool saltando = Input.GetKey(KeyCode.Space); // se asigna si se preciono Spacio para saltar
        if(saltando && puedeSaltar){ //Se comprubea si se preciono Espacio y Puede saltar
            velocidad = 2f;
            posInicialSalto = transform.position.y; //Se asigna la posicion antes de saltar
            rb2d.gravityScale = 1; //Se activa la gravedad
            rb2d.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar = false;
            comprobandoSalto = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void compararPosicion(){
        if(posInicialSalto > transform.position.y){ //Comprueba si la posicion antes de saltar es menor o igual a la posicion que tiene actualemtne
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY; //Congela la posicion en Y
            rb2d.gravityScale = 0; //Desactiva la gravedad
            puedeSaltar = true;
            comprobandoSalto = false;
            velocidad = 5f;
            animator.SetBool("IsJumping", false);
            rb2d.constraints = RigidbodyConstraints2D.None; //Descongelamos la rotacion y Movimientos
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; //Congelamos la rotación
        }
    }
}