using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterVfx : MonoBehaviour
{

    [SerializeField] int amountOfP = 5;
    [SerializeField] GameObject[] sprites;
    [SerializeField] GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = this.transform.position;
        sprites = new GameObject[amountOfP];
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = GameObject.Instantiate(particle, 
                new Vector3 (pos.x,pos.y,pos.z),this.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
