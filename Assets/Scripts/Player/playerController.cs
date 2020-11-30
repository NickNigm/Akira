using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public Text txtEnergia;
    public Text txtVida;
    public int energia;
    public int vida;

    public void cambioEnergia(int energiaModificar, bool ocupo){
        if(ocupo) energia -= energiaModificar;
        else energia += energiaModificar;
        txtEnergia.text = "Energia: " +energia+ "%";
    }

    public void cambioVida(int vidaModificar, bool daño){
        if(daño) vida -= vidaModificar;
        else vida += vida;
        txtVida.text = "Vida: " +vida+ "%";
    }
}
