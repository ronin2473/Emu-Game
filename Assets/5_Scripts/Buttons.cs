using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private string sceneToSwapTo;
    [SerializeField] Texture2D customCursor;

    public static string previousScene;


    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);

        previousScene = SceneManager.GetActiveScene().name;
        Debug.Log(previousScene);

        AudioManager audi =  FindObjectOfType<AudioManager>();
        audi.PlayMusic("MenuMusic");

    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void GameOptions()
    {
        SceneManager.LoadScene("ConfigUWUrama");
    }

    public void GameStart()
    {
        SceneManager.LoadScene(sceneToSwapTo);
    }

    public void GameCredits()
    {
        
        SceneManager.LoadScene("WhoDidIt");
    }

    public void GameHistory()
    {

    }
}
