using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmuName : MonoBehaviour
{
    
    int charid = CharController.choosenChar;
    string words;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Emu.ChoosenEmu charc = Emu.emus[charid];
        words = charc.emuName;
        text.text = words;
    }

    void Update()
    {
        charid = CharController.choosenChar;
        Emu.ChoosenEmu charc = Emu.emus[charid];
        words = charc.emuName;
        text.text = words;
    }
}
