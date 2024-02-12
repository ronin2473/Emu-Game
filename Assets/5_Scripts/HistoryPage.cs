using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class HistoryPage : MonoBehaviour
{
    public VideoPlayer videoplayer;
    public VideoClip video;
    public string menu;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            videoplayer.clip = video;
            videoplayer.Play();
            StartCoroutine(GoToMenu());
        }
    }



    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene(menu);
        StopCoroutine(GoToMenu());
    }
}
