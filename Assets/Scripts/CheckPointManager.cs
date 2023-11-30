using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Checkpoint[] AllCp;
    private Checkpoint activeCheckpoint;
    public Vector3 respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        AllCp = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
        foreach (Checkpoint checkpoint in AllCp)
        {
            checkpoint.cpMan = this;
        }
        respawnPosition=FindFirstObjectByType<PlayerController>().transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DeactivateAllCheckpoints();
        }
    }
    public void DeactivateAllCheckpoints()
    {
        foreach (Checkpoint checkpoint in AllCp) {
         
        checkpoint.DeactivateCheckPoints();
        
        }
    }
    public void SetCheckPoint(Checkpoint newActiveCP)
    {
        DeactivateAllCheckpoints();
        activeCheckpoint = newActiveCP;
        respawnPosition = newActiveCP.transform.position;
    }
}
