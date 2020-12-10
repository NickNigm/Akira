using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public Shield sEscudo;
    public GameObject prefabSangrar;
    private ParticleSystem pSangrar;
    private Renderer colorear;
    public Text txtEnergia;
    public Text txtVida;
    public float energia;
    public float vida;

    void Start()
    {
        pSangrar = prefabSangrar.GetComponent<ParticleSystem>();
        colorear = GetComponent<Renderer>();
        pSangrar.Stop();    
    }

    public void cambioEnergia(float energiaModificar, bool ocupo){
        if(ocupo) energia -= energiaModificar;
        else energia += energiaModificar;
        txtEnergia.text = "Energia: " +energia.ToString("f2")+ "%";
    }

    public void cambioVida(float vidaModificar, bool daño){
        if(daño && sEscudo.activarDaño == true){
            pSangrar.Play();
            vida -= vidaModificar;
        } 
        else vida += vida;
        txtVida.text = "Vida: " +vida.ToString("f2")+ "%";
    }
}
