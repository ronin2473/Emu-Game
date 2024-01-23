using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Startup : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer video;
    void Start()
    {
 
        video.Play();
        
    }

    private void Update()
    {
        if (video.isPrepared)
        {
            rawImage.texture = video.texture;
        }
        if ((video.length == video.clockTime ||  Input.GetButtonDown("Cancel"))) 
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame

}
