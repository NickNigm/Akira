using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float fuerzaSalto;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Salto());
    }

    Vector2 posOriginal;
    IEnumerator Salto()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            posOriginal = new Vector2(rb.position.x, rb.position.y);
            animator.SetBool("IsJumping", true);
            posOriginal.y = rb.position.y;
            rb.position = rb.position + (Vector2.up * fuerzaSalto);
            yield return new WaitForSeconds(1);
            animator.SetBool("IsJumping", false);
            rb.position = new Vector2(rb.position.x, posOriginal.y);
        } 
    }

}
