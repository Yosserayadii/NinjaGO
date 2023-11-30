using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
   public int healthtoadd;
    private void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (other.CompareTag("Player"))
        {
            if(PlayingHealthController.instance.currentHealth !=PlayingHealthController.instance.maxHealth) {
                PlayingHealthController.instance.AddHealth(healthtoadd);
                Destroy(gameObject);
            }
           
        }
    }
}
