using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private string sceneToSwapTo;
    public void GameQuit()
    {
        Application.Quit();
    }
    public void GameOptions()
    {
        Debug.Log("No option tab implemented yet");
    }

    public void GameStart()
    {
        SceneManager.LoadScene(sceneToSwapTo);
    }
}
