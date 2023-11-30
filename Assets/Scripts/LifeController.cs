using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class LifeController : MonoBehaviour
{  public static LifeController instance;
    private PlayerController thePlayer;
    public float respawnDelay = 2f;
    public int currentLives = 5;
  
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        //thePlayer.transform.position = FindFirstObjectByType<CheckPointManager>().respawnPosition;
        //PlayingHealthController.instance.AddHealth(PlayingHealthController.instance.maxHealth);
        currentLives--;
        thePlayer.gameObject.SetActive(false);
        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
        }
        else
        {
            currentLives = 0;
            StartCoroutine(GameOverCo()); 
        }
        UpdateDisplay();
     
       
    }
    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        thePlayer.transform.position = FindFirstObjectByType<CheckPointManager>().respawnPosition;
        PlayingHealthController.instance.AddHealth(PlayingHealthController.instance.maxHealth);
        thePlayer.gameObject.SetActive(true);
    }
    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        if(UIController.instance!=null)
        {
            UIController.instance.ShowGameover(); 
        }
    }
    public void AddLife()
    {
        currentLives++;
        AudioManager.instance.PlaySFX(8);
    }
    public void UpdateDisplay()
    {
        UIController.instance.UpdateLivesDisplay(currentLives);
    }
}
