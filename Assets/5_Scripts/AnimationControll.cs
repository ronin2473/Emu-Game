using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationControll : MonoBehaviour
{
    Animator animator;
    private int ID = CharController.choosenChar;
    [SerializeField] GameObject player;
    [SerializeField] string deathscene;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ID",ID);

    }

    // Update is called once per frame
    void Update()
    {
        float movement = (Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y));
        animator.SetFloat("Speed", movement);
    }

    private void Deathscene()
    {
        SceneManager.LoadScene(deathscene);
    }
}
