using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
   void Update()
    {
        Mover();
    }

    /**Aspecto generales del Jugador**/
    public float velocidad = 7f;

    /**Componentes del Jugador**/
    private void Mover() {
        float posX = velocidad * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(posX, 0, 0);

        float posY = velocidad * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0, posY, 0);
    }
}