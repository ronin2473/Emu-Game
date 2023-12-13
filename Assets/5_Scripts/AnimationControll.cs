using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    Animator animator;
    private int ID = CharController.choosenChar;
    [SerializeField] GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ID",ID);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
