using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WuffyAudioStuffy : MonoBehaviour
{
    SetAudio audio;
    //public static WuffyAudioStuffy instance;
    public Slider general;
    public Slider music;
    public Slider sfx;
    //Slider generalSlider;
    //Slider musicSlider;
    //Slider sfxSlider;
    public AudioManager am;



    private void Start()
    {
        audio = FindObjectOfType<SetAudio>();
        general.minValue = -40f;
        general.maxValue = 20f;
        music.minValue = -40f;
        music.maxValue = 20f;
        sfx.minValue = -40f;
        sfx.maxValue = 20f;
        general.value = PlayerPrefs.GetFloat("GeneralValue");
        music.value = PlayerPrefs.GetFloat("MusicValue");
        sfx.value = PlayerPrefs.GetFloat("SfxValue");

        
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
           
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SaveSliderValue();
            SceneManager.LoadScene("Menu");            
        }
        audio.SetMasterVolume(general.value);
        audio.SetMusicVolume(music.value);
        audio.SetSfxVolume(sfx.value);    

    }

    public void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("GeneralValue",general.value);
        PlayerPrefs.SetFloat("MusicValue",music.value);
        PlayerPrefs.SetFloat("SfxValue",sfx.value);
        PlayerPrefs.Save();
    }

}
