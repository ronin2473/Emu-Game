using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConformationButton : MonoBehaviour
{
    
    [SerializeField] Texture2D customCursor;
    [SerializeField] Button[] buttons;
    public Animator animator;
    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
        animator.GetComponent<Animator>().enabled = false;
    }
    public void ChangeScene() //dosnt change Scene anymore, only dos the animation part before changing scenes
    {
        animator.SetBool("selected", true);
        animator.SetInteger("id", CharController.choosenChar);
        foreach (var button in buttons)
        {
            button.enabled = false;
        }
        animator.enabled = true;        
        //SceneManager.LoadScene(gameScene);
    }

    
}
