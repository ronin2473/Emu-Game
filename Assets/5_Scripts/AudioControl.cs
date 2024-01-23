using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AudioControl : MonoBehaviour
{

    public AudioSource sound;
    private static AudioControl instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, make this the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sound.pitch = Random.Range(0.00000001f, 2f); ;
            sound.Play();
        }
    }

    
}
