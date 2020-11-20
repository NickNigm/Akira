using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    bool puedeSaltar = true, comprobandoSalto = false;
    public float fuerzaSalto;
    public float posInicialSalto;


    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update() {
        StartCoroutine(salto());
        if(comprobandoSalto) compararPosicion();
    }

    IEnumerator salto(){
        bool saltando = Input.GetKey(KeyCode.Space);
        if(saltando && puedeSaltar){
            posInicialSalto = transform.position.y;
            rb2d.gravityScale = 1;
            rb2d.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar = false;
            yield return new WaitForSeconds(0.1f);
            comprobandoSalto = true;
        }
    }

    void compararPosicion(){
        if(posInicialSalto > transform.position.y){
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2d.gravityScale = 0;
            puedeSaltar = true;
            comprobandoSalto = false;
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
