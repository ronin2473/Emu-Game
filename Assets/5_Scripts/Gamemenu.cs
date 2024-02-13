using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemenu : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] Texture2D customCursor;
    bool paused = false;
    public ButtonTraversing buttontravel;
    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
        button1.SetActive(false);
        button2.SetActive(false);
    }
    public void Menu()
    {
        
        paused = !paused;
        buttontravel.enabled = paused;
        if (paused)
        {
            buttontravel.x = 2;
            buttontravel.y = 0;
            Time.timeScale = 0;
        }
        else
        {
            buttontravel.UnHover();
            Time.timeScale = 1;
        }
        button1.SetActive(!(button1.activeSelf));
        button2.SetActive(!(button2.activeSelf));
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
