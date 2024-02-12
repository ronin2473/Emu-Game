using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimMusicalabim : MonoBehaviour
{
    public AudioManager audio;
    public AudioSource source;
    public AudioClip clip;
    public SetAudio set;

    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        source = audio.musicSource;
        clip = audio.musicSounds[0].clip;
        set = audio.GetComponent<SetAudio>();
        
        if (source.clip == null ||  clip == null || source.clip.name != clip.name) 
        {
            audio.PlayMusic("MenuMusic");
        }

        set.SetSfxVolume(PlayerPrefs.GetFloat("SfxValue"));
        set.SetMusicVolume(PlayerPrefs.GetFloat("MusicValue"));
        set.SetMasterVolume(PlayerPrefs.GetFloat("GeneralValue"));
        //else
        //{

        //}
    }
}
