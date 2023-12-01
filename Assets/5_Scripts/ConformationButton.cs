using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConformationButton : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] Texture2D customCursor;
    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(gameScene);

    }
}
