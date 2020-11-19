using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]//Con esto podemos ver los cambios sin necesidad de darle play
[RequireComponent(typeof(SpriteRenderer))]//Para agrager el componente de spriterenderer de forma automatica
public class OrderInLayer : MonoBehaviour
{
    SpriteRenderer sr;//Definimos nuestro sprite render 
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();//Inicializamos el sprite renderer   
    }

    void Update()
    {
        /*Modificamos la capa en la que se encuentra el 
        jugador dependiendo de su posicion en Y*/
        sr.sortingOrder = -(int)(transform.position.y * 100);
    }
}

