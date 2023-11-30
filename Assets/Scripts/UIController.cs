using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] heartIcons;
    public static UIController instance;
    public Sprite heartFull, heartEmpty;
    public TMP_Text livesText;
    public GameObject gameoverscreen;
    public TMP_Text CollectibleText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameoverscreen.SetActive(false);
    
}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthDisplay(int health)
    {
        for(int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;
            /*if (health <= i)
            {
                heartIcons[i].enabled = false;
            }*/
            if (health > i)
            {
                heartIcons[i].sprite= heartFull;    

            } else
            {
                heartIcons[i].sprite = heartEmpty;
            }
        }
    }
    public void UpdateLivesDisplay(int currentLives)
    {
        livesText.text = currentLives.ToString();
    }
    public void ShowGameover()
    {
        gameoverscreen.SetActive(true);    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateCollectibles(int amount)
    {
        CollectibleText.text = amount.ToString();
    }
}
