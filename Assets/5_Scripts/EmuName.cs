using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmuName : MonoBehaviour
{
    
    int charid = CharController.choosenChar;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI speed;
    public List<float> damages;
    string words;
    public TextMeshProUGUI text;
    public List<Sprite> weaponimgs;
    public Image weaponimage;

    void Start()
    {
        
        
    }

    void Update()
    {
        charid = CharController.choosenChar;
        Emu.ChoosenEmu charc = Emu.emus[charid];
        weaponimage.sprite = weaponimgs[charid];
        words = charc.emuName;
        text.text = words;
        words =  charc.maxHealth.ToString();
        health.text = ($"Health: {words}") ;
        words = charc.speed.ToString();
        speed.text = ("Speed: " + words).ToString();
        words = damages[charid].ToString();
        damage.text = "Damage: " + words;
    }
}
