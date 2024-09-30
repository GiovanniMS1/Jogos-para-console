using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int tempoDeVida = 3;
    public int damage;
    public RaycastHit rayHit;

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Ground") || other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, tempoDeVida);
        }
    }
    
}
