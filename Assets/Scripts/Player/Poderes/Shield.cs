using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public playerController sPC;
    public AudioSource sonido;
    public AudioClip sdEscudo;
    public GameObject prefabEscudo;
    private ParticleSystem pEscudo;
    public Text txtEscudo;
    private Renderer colorear;
    public bool puedeEscudo; //Variable para saber si puede usar escudo
    public bool activarDaño; //Activar daño o no del personaje
    public bool iniciarContador;
    public float timepoActivo; //Tiempo de duracion del escudo
    public float enfriamientoEscudo; //Tiempo activo que dura el enfriamiento
    public float costoEnergia;
    public float enfriamientoHabilidad;
    public float tiempoEnfriamientoActivo;

    void Start()
    {
        sonido = GetComponent<AudioSource>();
        pEscudo = prefabEscudo.GetComponent<ParticleSystem>();
        pEscudo.Stop();
        colorear = GetComponent<Renderer>();
        timepoActivo = enfriamientoEscudo;
        puedeEscudo = true;
        activarDaño = true;
        iniciarContador=false;
        cambiarColor(Color.white);
        tiempoEnfriamientoActivo = enfriamientoHabilidad;
    }

    void Update()
    {
        iniciar();
        if(iniciarContador){
            tiempoEnfriamientoActivo -= Time.deltaTime;
            txtEscudo.text = "Escudo: " + tiempoEnfriamientoActivo.ToString("f2");    
        }
        if(iniciarContador == false && sPC.energia >= costoEnergia) txtEscudo.text = "Escudo Listo";
        if(sPC.energia<costoEnergia) txtEscudo.text = "Sin Escudo";
        if(activarDaño == false) Escudo();
        
    }
    
    void Escudo(){
        if(timepoActivo>0){
            timepoActivo -= Time.deltaTime;
            cambiarColor(Color.green);
            txtEscudo.text = "Usando Escudo";
        }else{
            activarDaño = true;
            cambiarColor(Color.white);
            timepoActivo=enfriamientoEscudo;
            StartCoroutine(enfriemientoH(enfriamientoHabilidad));
        }
    }

    void iniciar(){
        bool protegiendo = Input.GetKey(KeyCode.E);
        if(protegiendo && puedeEscudo && sPC.energia >= costoEnergia){
            pEscudo.Play();
            sonido.clip = sdEscudo;
            sonido.Play();
            puedeEscudo = false;
            activarDaño = false;
            sPC.cambioEnergia(costoEnergia, true);
        }
    }

    void cambiarColor(Color nombreColor){
        colorear.material.color = nombreColor;
    }

    IEnumerator enfriemientoH(float etoHabilidad){
        iniciarContador = true;
        yield return new WaitForSeconds(etoHabilidad);
        puedeEscudo = true;
        iniciarContador = false;
        tiempoEnfriamientoActivo = enfriamientoHabilidad;

    }
}
