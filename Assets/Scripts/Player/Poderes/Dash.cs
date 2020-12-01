using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public playerMov sPlayerMov; //cominicamos con el script playerMov
    public playerController sPC; //cominicamos con el script playerController
    public Text txtDash;
    public float fuerzaDash;
    public float desplazamiento; //La distancia maxima del desplazamiento
    public float inicioDash; //la pocision inicial antes de desplazarse
    public int energiaNecesaria;
    public float timepoEnfriamiento;
    public float tiempoActual;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    bool couroutineStarted = false;
    public bool desplazandose = false;
    public bool puedeDash = true;
    public bool derecha; //para comprobar de que lado se ejecuta el dash derecha o izquierda
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tiempoActual = timepoEnfriamiento;
    }

    // Update is called once per frame
    void Update()
    {
        dash();
        if(desplazandose)comparacionDash(); //Comprobamos la distancia del dash
        
        if(couroutineStarted){
            tiempoActual = tiempoActual - 1 * Time.deltaTime;
            txtDash.text = "Enfriemieto: " + tiempoActual.ToString("f2");        
        }
        
        if(couroutineStarted == false && sPC.energia >= energiaNecesaria) txtDash.text = "Dash Listo";
        if(sPC.energia<energiaNecesaria) txtDash.text = "Sin Dash";
    }

    void dash(){
        bool dashing = Input.GetKey(KeyCode.LeftShift);
        if(dashing && puedeDash && (sPC.energia>=energiaNecesaria)){ //Puede hacer el dash solo si; se preciono lshifth, puede puedeDash=true y la energia es igual o mayor a la necesaria
            desplazandose = true;
            inicioDash = transform.position.x; //Guardamos la pocision del dash
            rb2d.gravityScale = 1;
            if(sPlayerMov.puedeSaltar==true)rb2d.constraints = RigidbodyConstraints2D.FreezePositionY; // conngelamos en y solo si no esta saltando
            //rb2d.AddForce(new Vector2(fuerzaDash, 0));
            if(sr.flipX){//tenerminamos la direccion del dash
                rb2d.AddForce(Vector2.left * fuerzaDash);
                derecha = false; 
            }else{//tenerminamos la direccion del dash
                rb2d.AddForce(Vector2.right * fuerzaDash);
                derecha = true;
            }
            puedeDash = false;
            sPC.cambioEnergia(energiaNecesaria, true); //cambiamos la energia actual
        }
    }

    void comparacionDash(){
        //comprobamos el desplazamiento
        if(derecha == true)if(transform.position.x > (inicioDash + desplazamiento)) detener();
        if(derecha == false) if(transform.position.x < (inicioDash - desplazamiento)) detener();
    }


    void detener(){
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX; //congelamos en x
        if(sPlayerMov.puedeSaltar==true) rb2d.gravityScale = 0; //desactivamos la gravedad solo si no esta saltando
        rb2d.constraints = RigidbodyConstraints2D.None; //activamos x,y,z y la rotacion
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; //desactivamos la rotacion
        desplazandose = false;
        StartCoroutine(enfriemientoDash(timepoEnfriamiento));
    }

    IEnumerator enfriemientoDash(float enfriamiento){
        couroutineStarted = true;
        //Debug.Log("Entro:" + couroutineStarted);
        yield return new WaitForSeconds(enfriamiento);
        couroutineStarted = false;
        //Debug.Log("Salio");
        puedeDash = true;
        tiempoActual = timepoEnfriamiento;
    }
}
