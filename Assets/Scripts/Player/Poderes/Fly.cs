using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public playerMov sPlayerMov;
    public playerController sPlayerController;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    
        
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        volar();
    }

    void volar(){
        sPlayerController.volando = Input.GetKey(KeyCode.LeftShift);
        if(sPlayerController.volando){
            rb2d.AddForce(new Vector2(0, 3f));
            rb2d.gravityScale = 0.2f;
        }
    }
}
