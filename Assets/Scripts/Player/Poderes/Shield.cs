using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    BoxCollider2D bc;//Box collider del escudo
    public float bcXY;//Dimenciones del box collider en X y Y
    
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();//Inicializamos nuestra variable de box collider  
    }

    //Iniciamos la corrutina de nuestro escudo si presionamos Q
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Escudo());
        }
    }

    //Corrutina de nuestro escudo
    IEnumerator Escudo()
    {
        /*Cambiamos las dimensiones de nuestro box collider
        La agrandamos multiplicandolas x10*/
        bc.size = new Vector2(bcXY * 10, bcXY * 10);
        yield return new WaitForSeconds(3);//Esperamos 3 segundos
        bc.size = new Vector2(bcXY, bcXY);//Regresamos el box collider a su dimension original
    }

}
