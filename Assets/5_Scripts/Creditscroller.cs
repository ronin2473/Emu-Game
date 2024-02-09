using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creditscroller : MonoBehaviour
{


    string scenename = VictoryScene.previousScene;
    Scrollbar scrolly;

    public static int timesplayed = 0;
    bool clicked = false;


    private void Start()
    {
        scrolly = FindObjectOfType<Scrollbar>();

        //AudioManager audi = FindObjectOfType<AudioManager>();
        //audi.PlayMusic("CreditMusic");
        Debug.Log(timesplayed);
        Debug.Log(scenename);
        if (scenename == "VictoryScreen" && timesplayed == 0)
        {
            Debug.LogWarning("test");
            timesplayed++;

        }
        else if (scenename == "Menu")
        {

        }
    }




    // Update is called once per frame
    void Update()
    {
        if (timesplayed != 1)
        {

            if (Input.anyKeyDown || Input.GetAxis("Mouse ScrollWheel") <= -0.05 || Input.GetAxis("Mouse ScrollWheel") >= 0.05)
            {
                Debug.Log(Input.anyKeyDown);
                Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

                clicked = true;
            }
        }
        if (clicked == false)
        {
            scrolly.value -= 0.006f * Time.deltaTime;
        }

        if (scrolly.value <= 0 && timesplayed == 1)
        {
            SceneManager.LoadScene("Menu");
        }
        //else if (scrolly.value >)



        Debug.Log(timesplayed);
        Debug.Log(scenename);

    }
}
