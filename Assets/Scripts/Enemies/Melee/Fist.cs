using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public playerController spc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("Player"))
            spc.cambioVida(10f, true);

    }
}
