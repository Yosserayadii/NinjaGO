using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickups : MonoBehaviour
{
    public int amount ;
    public GameObject pickUpEffect ;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           if(CollectibleManager.instance!=null) {
                CollectibleManager.instance.GetColectible(amount);
                Destroy(gameObject);
                Instantiate(pickUpEffect, transform.position, Quaternion.identity);
                AudioManager.instance.PlaySFXPITCH(9);

            }
        }
    }
}
