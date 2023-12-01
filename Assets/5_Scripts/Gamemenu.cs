using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemenu : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

    private void Start()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }
    public void Menu()
    {
        button1.SetActive(!(button1.activeSelf));
        button2.SetActive(!(button2.activeSelf));
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
