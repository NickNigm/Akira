using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{

    public playerController sPC;

    public float velocidad = 50f;
    public float incremento = 2.5f;
    public float decremento = 0.2f;
    public float costoEnergia = 100f;
    public float minimoEnergia = 10f;

    public bool expandiendose = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        comprobarExpancion();
    }

    void comprobarExpancion(){
        expandiendose = Input.GetKey(KeyCode.Q);
        if(expandiendose && sPC.energia>=minimoEnergia) expandir();
        else comprimir();
    }

    void expandir(){
        float x = transform.localScale.x, y = transform.localScale.y, z = transform.localScale.z;
        if(transform.localScale.x < incremento && transform.localScale.y < incremento && transform.localScale.z < incremento)
        transform.localScale = new Vector3(x+Time.deltaTime*velocidad, y+Time.deltaTime*velocidad, z+Time.deltaTime*velocidad);
        sPC.cambioEnergia(costoEnergia * Time.deltaTime, true);
    }

    void comprimir(){
        float x = transform.localScale.x, y = transform.localScale.y, z = transform.localScale.z;
        if(transform.localScale.x > decremento && transform.localScale.y > decremento && transform.localScale.z > decremento)
        transform.localScale = new Vector3(x-Time.deltaTime*velocidad, y-Time.deltaTime*velocidad, z-Time.deltaTime*velocidad);
    }
    
}
