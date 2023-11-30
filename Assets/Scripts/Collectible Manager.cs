using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;
    
    public int extraLifeThersold;
    private void Awake()
    {
        instance = this;
    }
    public int collectibleCount;
    // Start is called before the first frame update
    void Start()
    {
        collectibleCount = InfoTracker.instance.currentFruits; 
        UIController.instance.UpdateCollectibles(collectibleCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetColectible(int amount)
    {
        collectibleCount += amount;
        if( collectibleCount >= extraLifeThersold)
        {
            collectibleCount -= extraLifeThersold;
            LifeController.instance.AddLife();
            
        }
      
            UIController.instance.UpdateCollectibles(collectibleCount);
        
    }
}
