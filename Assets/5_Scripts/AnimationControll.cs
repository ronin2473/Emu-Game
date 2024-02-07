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
    public float deathdelay;
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
        StartCoroutine(DeathScenetransition());
    }

    IEnumerator DeathScenetransition()
    {
        yield return new WaitForSeconds(deathdelay);
        SceneManager.LoadScene(deathscene);
        StopCoroutine(DeathScenetransition());
    }
}
