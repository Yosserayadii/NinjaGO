using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTracker : MonoBehaviour

{
    public static InfoTracker instance;
    public int currentLives;
    public int currentFruits;
    // Start is called before the first frame update

    private void Awake()
    {   if (instance == null) {
        instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getInfor()
    {
        if(LifeController.instance != null)
        {
            currentLives = LifeController.instance.currentLives;

        }
        if (CollectibleManager.instance != null)
        {
            currentFruits = CollectibleManager.instance.collectibleCount;
        }
    }
}
