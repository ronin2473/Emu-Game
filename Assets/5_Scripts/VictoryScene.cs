

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

    int alreadywon = Creditscroller.timesplayed;

    [SerializeField] string creditscene;
    public float victorydelay;
    AudioSource victorysound;
    // Start is called before the first frame update
    void Start()
    {
        victorysound = GetComponent<AudioSource>();
        StartCoroutine(Victory());
        previousScene = SceneManager.GetActiveScene().name;
    }


    // Update is called once per frame
    void Update()
    {
        if (video.isPrepared)
        {
            rawImage.texture = video.texture;

            if (alreadywon < 1)
            {
                StartCoroutine(VictoryScenetransition());
            }
            else if (alreadywon >= 1)
            {
                creditscene = "Menu";

                StartCoroutine(VictoryScenetransition());
            }
                

        }
        
    }
    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2);
        victorysound.Play();
        StopCoroutine(Victory());   
    }
    IEnumerator VictoryScenetransition()
    {
        yield return new WaitForSeconds(victorydelay);
        SceneManager.LoadScene(creditscene);
        StopCoroutine(VictoryScenetransition());
    }

}
