using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyHit : MonoBehaviour
{
    public int Damage=5;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakenDamage(Damage);
            
        }
    }
}

