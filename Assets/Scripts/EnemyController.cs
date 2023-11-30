using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    public float WaitToDestroy;
    public bool isDefeated;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeated==true)
        {
            WaitToDestroy -=Time.deltaTime;
            if(WaitToDestroy <= 0) {
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(5);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayingHealthController.instance.DamagePlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            //  Destroy(gameObject);
            anim.SetTrigger("Defeated");
            isDefeated = true;
            AudioManager.instance.PlaySFX(6);
        }
    }
}
