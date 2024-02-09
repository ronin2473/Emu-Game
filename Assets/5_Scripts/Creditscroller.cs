using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creditscroller : MonoBehaviour
{


    string scenename = VictoryScene.previousScene;
    Scrollbar scrolly;

    int timesplayed = 0;
    bool clicked = false;


    private void Start()
    {
        scrolly = FindObjectOfType<Scrollbar>();

        if (scenename == "VictoryScene" && timesplayed < 1)
        {
            timesplayed++;

            

        }
        else if (scenename == "Menu")
        {

        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetAxis("Mouse ScrollWheel") <= -0.05 || Input.GetAxis("Mouse ScrollWheel") >= 0.05)
        {
            Debug.Log(Input.anyKeyDown);
            Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

            clicked = true;
        }

        if (clicked == false)
        {
            scrolly.value -= 0.006f * Time.deltaTime;
        }

    }
}
