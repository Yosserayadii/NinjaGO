using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource[] AllSFX;
    private void Awake()
    { if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    public AudioSource menuMusic, BossMusic, LevelCompleteMusic;
    public AudioSource[] levelTracks;
    
    public void StopMusic()
    {
        menuMusic.Stop();
        BossMusic.Stop();
        LevelCompleteMusic.Stop();
        foreach(AudioSource source in levelTracks)
        {
            source.Stop();   
        }
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }
    public void PlayBossMusic()
    {
        StopMusic();
        BossMusic.Play();

    }
    public void PlayLevelMusic()
    {
        StopMusic();
        PlayBossMusic();
    }
    public void PlayLevelMusic(int TrackToPlay)
    {
        StopMusic();
        levelTracks[TrackToPlay].Play();
    }
    public void PlaySFX(int sfxtoplay)
    {
        AllSFX[sfxtoplay].Stop();
        AllSFX[sfxtoplay].Play();
    
    }
   public void PlaySFXPITCH(int sfxtoplay)
    {
        AllSFX[sfxtoplay].Stop();
        AllSFX[sfxtoplay].pitch=Random.Range(.75f, 1.25f);
        AllSFX[sfxtoplay].Play();
    }
}
