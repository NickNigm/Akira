using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    public float radioExplo;//Radio de nuestra explosion
    public float fuerzaExplo;//Fuerza de nuestra explosion

    public LayerMask capaAfectada;//Capa que queremos afectar


    /*Activamos nuestro metodo de explosion si presionamos la tecla E*/
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Explosion();
        }
        
    }

    //Nuestra explosion, lo que se encuentre en la capa Empujables se vera afectado por esto
    void Explosion()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, radioExplo, capaAfectada);
        foreach (Collider2D obj in objs)
        {
            Vector2 direccion = obj.transform.position - transform.position;/*Direccion en la que
            los objetos saldran empujados restando su posicion con la del player*/
            obj.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaExplo);//Empujamos al objeto
        }
    }

    //Gizmo para ver nuestro radio de alcance
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplo);
    }


}
