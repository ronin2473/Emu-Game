using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestWeaponBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject weapon;
    float time = 0f;
    float timetowait = 2f;

    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timetowait) 
        {
            SwingWeapon();
            time= 0f;
        
        }


    }
    void SwingWeapon()
    {
        weapon.SetActive(true);


 
        StartCoroutine(EndOfSwing(0.5f));
        
    } 

    IEnumerator EndOfSwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        weapon.SetActive(false);
        StopCoroutine(EndOfSwing(delay));   
    }
    
    
    
   
}
