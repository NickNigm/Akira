using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{

    public playerController sPlayerController;
    public BasicAttacks sBA;
    public GameObject prefabSalto;
    private ParticleSystem pSalto;

    //Componentes del objeto
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    //Variables para limitar el salto a 1 y comprobar si se debe medir la distancia del salto
    public bool puedeSaltar = true;
    public bool comprobandoSalto = false;
    public float fuerzaSalto;
    public float velocidad;
    public float posInicialSalto; //Guarda la posicion en Y del objeto antes de saltar
    //public float velocidad; //Velocidad de movimiento

    //Iniciamos los componenetes
    void Start(){
        pSalto = prefabSalto.GetComponent<ParticleSystem>();
        pSalto.Stop();
        asignarVelocidad(2f);
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

    public void Mover() {
        float posX = velocidad * Time.deltaTime * Input.GetAxisRaw("Horizontal"); //asigna el movimiento del eje X a posX
        transform.position += new Vector3(posX, 0, 0); // PosX agrega el movimiento en el eje X
        
        if( posX != 0 ) sr.flipX = posX < 0; //Inivter el sprite al moverse atras en el eje X

        //Comprueba si el objeto puede saltar
        if(puedeSaltar){
            //Cambia la animacion a Correr si se preciona A o D
            animator.SetBool("IsRunning", Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.W));
            float posY = velocidad * Time.deltaTime * Input.GetAxisRaw("Vertical"); //asigna el movimiento del eje Y a posY
            transform.position += new Vector3(0, posY, 0);  // PosY agrega el movimiento en el eje Y
        }
    }

    void salto(){
        bool saltando = Input.GetKey(KeyCode.Space); // se asigna si se preciono Spacio para saltar
        if(saltando && puedeSaltar){ //Se comprubea si se preciono Espacio y Puede saltar
            asignarVelocidad(1f);
            posInicialSalto = transform.position.y; //Se asigna la posicion antes de saltar
            rb2d.gravityScale = 1; //Se activa la gravedad
            rb2d.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar = false;
            comprobandoSalto = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void compararPosicion(){
        if(posInicialSalto > transform.position.y){ //Comprueba si la posicion antes de saltar es menor o igual a la posicion que tiene actualemtne
            pSalto.Play();
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY; //Congela la posicion en Y
            rb2d.gravityScale = 0; //Desactiva la gravedad
            puedeSaltar = true;
            comprobandoSalto = false;
            asignarVelocidad(2f);
            animator.SetBool("IsJumping", false);
            rb2d.constraints = RigidbodyConstraints2D.None; //Descongelamos la rotacion y Movimientos
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; //Congelamos la rotación
        }else{
            asignarVelocidad(1f);
        }
    }

    public void asignarVelocidad(float vel){
        velocidad = vel;
    }

}