using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathVideo : MonoBehaviour
{
    public AudioSource gameOver;
    private VideoPlayer video;
    RawImage rawImage;
    int videoId = CharController.choosenChar;
    [SerializeField] private string mainmenu;
    [SerializeField] private VideoClip[] videos;
    // Start is called before the first frame update
    void Start()
    {
        video = this.gameObject.GetComponent<VideoPlayer>();
        video.clip = videos[videoId];
        rawImage = GetComponent<RawImage>();
        StartCoroutine(GameOver());
        video.Play();
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
        
        StartCoroutine(MainMenu());
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0f);
        gameOver.Play();
        StopCoroutine(GameOver());
    }
    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(mainmenu);
        StopCoroutine(MainMenu());
    }
}
