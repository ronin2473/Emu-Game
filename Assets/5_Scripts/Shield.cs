using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : WeaponManagement.weapon
{
    public List<shieldinstance> shields;
    public GameObject player;
    public float speed;
    private bool leveled2 = false;
    private bool leveled3 = false;
    public float level2damage;
    public float level3damage;
    public AudioSource shieldAudio;
    public Shield(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
    {


    }

    private void Start()
    {
        shields[0].Randomr(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (level >= 2 && !leveled2)
        {
            shieldinstance tmp = Instantiate(shields[0]);
            tmp.Randomr(3f);
            tmp.shieldaudio = shieldAudio;
            shields.Add(tmp);
            leveled2 = true;
            foreach (shieldinstance shield in shields)
            {
                shield.damage = level2damage;
            }
        }

        if (level >= 3 && !leveled3)
        {
            shieldinstance tmp = Instantiate(shields[0]);
            tmp.Randomr(4.5f);
            tmp.shieldaudio = shieldAudio;
            shields.Add(tmp);
            leveled3 = true;
            foreach (shieldinstance shield in shields)
            {
                shield.damage = level3damage;
            }
        }
        foreach (var shield in shields) 
        {
            shield.damage = damage;
            shield.player = player.transform;
            shield.speed = speed;
            shield.Movearound();
        }
    }
}
