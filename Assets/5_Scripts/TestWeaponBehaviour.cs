using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TestWeaponBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject[] weapon;
    [SerializeField] public GameObject player;
    float time = 0f;
    float timetowait = 2f;
    public float weaponSwingTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        weapon[0].SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timetowait) 
        {
            SwingWeapon(weaponSwingTime, weapon[0], Vector3.zero);
            time= 0f;
        
        }

            
    }
    void SwingWeapon(float time, GameObject weapon, Vector3 displacement)
    {
        weapon.SetActive(true);
        weapon.transform.position = player.transform.position + (new Vector3(1,0,0)*Mathf.Sign(player.transform.localScale.x));
        StartCoroutine(EndOfSwing(time));
        
    } 

    IEnumerator EndOfSwing(float delay)
    {
        yield return new WaitForSeconds(delay);
        weapon[0].SetActive(false);
        StopCoroutine(EndOfSwing(delay));   
    }
    
    
    
   
}
