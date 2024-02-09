using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WuffyAudioStuffy : MonoBehaviour
{
    SetAudio audio;
    public Slider general;
    public Slider music;
    public Slider sfx;

    private void Start()
    {
        audio = FindObjectOfType<SetAudio>();
        general.minValue = -80f;
        general.maxValue = 20f;
        music.minValue = -80f;
        music.maxValue = 20f;
        sfx.minValue = -80f;
        sfx.maxValue = 20f;
        general.value = 0f;
        music.value = 0f;
        sfx.value = 0f;


    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        audio.SetMasterVolume(general.value);
        audio.SetMusicVolume(music.value);
        audio.SetSfxVolume(sfx.value);


    }
}
