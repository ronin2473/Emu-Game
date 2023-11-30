using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConformationButton : MonoBehaviour
{
    [SerializeField] private string gameScene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(gameScene);

    }
}
