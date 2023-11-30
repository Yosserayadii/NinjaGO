using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActive;
    public Animator anim;
    public CheckPointManager cpMan;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if( other.tag=="Player" && isActive==false)
        {
            cpMan.SetCheckPoint(this);
            anim.SetBool("IsActive", true);
            isActive = true;
            AudioManager.instance.PlaySFX(3);
        }
    }
    public void DeactivateCheckPoints()
    {
        anim.SetBool("IsActive", false);
        isActive = false;   
    }
}
