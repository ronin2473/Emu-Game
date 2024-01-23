

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VictoryScene : MonoBehaviour
{

    public VideoPlayer video;
    public RawImage rawImage;
    public string mainmenu;
    // Update is called once per frame
    void Update()
    {
        if (video.isPrepared)
        {
            rawImage.texture = video.texture;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(mainmenu);
        }
    }
}
