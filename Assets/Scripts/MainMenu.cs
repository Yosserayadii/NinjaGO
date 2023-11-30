using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstlevel;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) ){
        
        AudioManager.instance.PlayLevelMusic(1);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(firstlevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
