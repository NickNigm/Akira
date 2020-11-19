using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMvm : MonoBehaviour
{

    static Vector2 LimiteY = new Vector2(-0.92f, 1.225f);

    [SerializeField]
    float velVert;
    [SerializeField]
    float velHorz;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    Vector2 ctrl;
    // Update is called once per frame
    void Update()
    {
        Mvm();

    }

    void Mvm()
    {
        ctrl = new Vector2(Input.GetAxisRaw("Horizontal"), 
        Input.GetAxisRaw("Vertical"));

        if(ctrl.x !=0)
            sr.flipX = ctrl.x < 0;
    
        animator.SetBool("IsRunning", ctrl.magnitude !=0);
        
        rb.velocity = new Vector2(ctrl.x * velHorz, ctrl.y * velVert);
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimiteY.x, LimiteY.y)
        , transform.position.z);

    }

}
