using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UIElements;

public class CharSelected : MonoBehaviour
{
    [SerializeField] private Sprite[] listofchar;
    int charID = CharController.choosenChar;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = listofchar[charID];
    }
    
   
}
