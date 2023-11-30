using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator anim;
    public string nextlevel;
    public float waittoendleve = 2f;
    private bool isending;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isending == false)
        {

     

        if(collision.CompareTag("Player"))
        {
            anim.SetTrigger("ended");
            isending = true;
               StartCoroutine(EndLevelCo()) ;
        }
        }
        
    }
    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waittoendleve); 
        SceneManager.LoadScene(nextlevel);
    }
}
