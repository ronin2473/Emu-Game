using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Startup : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    RawImage rawImage;
    VideoPlayer video;
    bool playing = false;
    void Start()
    {
        video = this.gameObject.GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();
        this.transform.position = mainmenu.transform.position;
        video.Play();
        mainmenu.SetActive(false);
        

    }

    private void Update()
    {
        if (video.isPrepared)
        {
            rawImage.texture = video.texture;
        }
        if ((video.length == video.clockTime ||  Input.GetButtonDown("Cancel")) && playing == false) 
        {
            playing = true;
            mainmenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame

}
