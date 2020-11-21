using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocidad;

    public bool volando;
    //Variables para limitar el salto a 1 y comprobar si se debe medir la distancia del salto
    public void asignarVelocidad(float vel){
        velocidad = vel;
    }
}
