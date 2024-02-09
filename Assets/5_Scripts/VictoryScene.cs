

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VictoryScene : MonoBehaviour
{

    public VideoPlayer video;
    public RawImage rawImage;
    public string mainmenu;

    public static string previousScene;

    // Start is called before the first frame update
    void Start()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }


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
