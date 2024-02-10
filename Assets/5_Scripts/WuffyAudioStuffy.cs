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
    static float generalDeleted;
    static float musicDeleted;
    static float sfxDeleted;


    private void Start()
    {
        audio = FindObjectOfType<SetAudio>();
        general.minValue = -40f;
        general.maxValue = 20f;
        music.minValue = -40f;
        music.maxValue = 20f;
        sfx.minValue = -40f;
        sfx.maxValue = 20f;
        general.value = generalDeleted;
        music.value = musicDeleted;
        sfx.value = sfxDeleted;
        

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
            SceneManager.LoadScene("Menu");
        }
        audio.SetMasterVolume(general.value);
        audio.SetMusicVolume(music.value);
        audio.SetSfxVolume(sfx.value);


    }
    void OnSceneUnload(Scene scene)
    {
        sfx.value = sfxDeleted;
        music.value = musicDeleted;
        general.value = generalDeleted;
    }
}
