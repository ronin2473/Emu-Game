using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [SerializeField] public Sprite[] chars;
    [SerializeField] private string gameScene;
    public static int choosenChar = 0;
    void Start()
    {
        Image selectedImage = GetComponent<Image>();
        selectedImage.sprite = chars[choosenChar];
    }

    public void ChoosingCharsplus()
    {
        choosenChar += 1;
        if (choosenChar >= chars.Length)
        {
            choosenChar = 0;
        }
        GetComponent<Image>().sprite = chars[choosenChar];
       }

    public void ChoosingCharsmin()
    {
        choosenChar -= 1;
        if (choosenChar < 0)
        {
            choosenChar = chars.Length - 1;
        }
        GetComponent<Image>().sprite = chars[choosenChar];

    }
    public void GetToGame()
    {
        SceneManager.LoadScene(gameScene);
    }

}
