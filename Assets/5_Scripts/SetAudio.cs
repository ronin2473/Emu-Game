using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetAudio : MonoBehaviour
{
    public AudioMixer audioMixer;

    /// <summary>
    /// Sets the Volume for the SFX components

    /// amount should be a float from -80f to 20f ,0f is the default volume , in our case thats the slider value
    /// pls only go from minus -80 to 20, i beg u 
    /// </summary>
    public void SetSfxVolume(float amount)
    {
        
        audioMixer.SetFloat("SFX", amount);
    }

    /// <summary>
    /// Sets the Volume for the Music components
    /// amount should be a float from -80f to 20f, in our case thats the slider value
    /// pls only go from minus -80 to 20, i beg u
    /// </summary>

    public void SetMusicVolume(float amount)
    {
        
        audioMixer.SetFloat("Music", amount);
    }

    /// <summary>
    /// Sets the Volume for the Master components
    /// amount should be a float from -80f to 20f, in our case thats the slider value
    /// pls only go from minus -80 to 20, i beg u
    /// </summary>
    public void SetMasterVolume(float amount)
    {

        audioMixer.SetFloat("Master", amount);
    }


    private void Start()
    {
        SetSfxVolume(0f);
        SetMusicVolume(0f);
    }
}
