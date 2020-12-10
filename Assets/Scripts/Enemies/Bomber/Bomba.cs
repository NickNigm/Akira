using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    //public playerController spc;
    public GameObject prefabExplosion;
    private ParticleSystem pExplosion;
    public float vel;
    private Transform player;
    private Vector2 objetivo;

    private void Start()
    {
        pExplosion = prefabExplosion.GetComponent<ParticleSystem>();
        pExplosion.Stop(); 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objetivo = new Vector2(player.position.x, player.position.y);
        var dir = -transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(dir * vel, ForceMode2D.Impulse);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo, vel * Time.deltaTime);
        if(transform.position.x == objetivo.x && transform.position.y == objetivo.y)
            DestroyBomb();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            DestroyBomb();
        }
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }
}

