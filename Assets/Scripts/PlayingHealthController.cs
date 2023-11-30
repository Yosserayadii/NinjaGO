using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingHealthController : MonoBehaviour
{
    
    public static PlayingHealthController instance;
    public float invincibiltyLength=1f;
    private float invincibiltyCounter;
    public SpriteRenderer theSR;
    public Color normalColor, fadeColor;
    private PlayerController thePlayer;

    private void Awake()
    {
        instance = this;
    }
    public int currentHealth, maxHealth;
// Start is called before the first frame update
    void Start()
    {
        thePlayer = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth);
    }
  
    // Update is called once per frame
    void Update()
    {
        if (invincibiltyCounter > 0)
        {
            invincibiltyCounter -= Time.deltaTime;
            if(invincibiltyCounter <= 0)
            {
                theSR.color = normalColor;
            }
        }
#if !UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H)) {
            AddHealth(1);
        }

   
#endif
    }
    public void DamagePlayer()
    { if (invincibiltyCounter <=0) { 
       
        currentHealth--;
        if(currentHealth <= 0) {
            currentHealth = 0;
                //gameObject.SetActive(false);
                LifeController.instance.Respawn();

        } else
            {
                invincibiltyCounter = invincibiltyLength;
                theSR.color = fadeColor;
                thePlayer.KnockBack();
                AudioManager.instance.PlaySFX(13);
                UIController.instance.UpdateHealthDisplay(currentHealth);
            }
        UIController.instance.UpdateHealthDisplay(currentHealth);
    }
    }
    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;
        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
     UIController.instance.UpdateHealthDisplay(currentHealth);
    }

}
