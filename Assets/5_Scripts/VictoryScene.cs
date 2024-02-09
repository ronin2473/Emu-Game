

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

    IEnumerator VictoryScenetransition()
    {
        yield return new WaitForSeconds(victorydelay);
        SceneManager.LoadScene(creditscene);
        StopCoroutine(VictoryScenetransition());
    }

}
