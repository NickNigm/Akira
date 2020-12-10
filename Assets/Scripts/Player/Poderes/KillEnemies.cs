using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemies : MonoBehaviour
{
    public GameObject prefabSangrar;
    private ParticleSystem pSangrar;

    private void Start()
    {
        pSangrar = prefabSangrar.GetComponent<ParticleSystem>();
        pSangrar.Stop(); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            Destroy(other.gameObject);
            pSangrar.Play();
    }
}
