using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private string sceneToSwapTo;
    [SerializeField] Texture2D customCursor;
    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }
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

    public void GameCredits()
    {
        
        //SceneManager.LoadScene("Credits");
    }
}
