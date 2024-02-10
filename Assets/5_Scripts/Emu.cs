using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Emu : MonoBehaviour
{

    [SerializeField] GameObject baseEmuStartWeapon;
    [SerializeField] GameObject alienEmuStartWeapon;
    [SerializeField] GameObject ritterEmuStartWeapon;
    [SerializeField] GameObject roadRunnerEmuStartWeapon;
    [SerializeField] GameObject pharaoEmuStartWeapon;
    public static ChoosenEmu emu1;
    public static ChoosenEmu emu2;
    public static ChoosenEmu emu3;
    public static ChoosenEmu emu4;
    public static ChoosenEmu emu5;
    public static ChoosenEmu[] emus = {emu1,emu2,emu3,emu4,emu5};
    [System.Serializable]
    public class ChoosenEmu
    {
        public int emuId;
        public string emuName;
        public int maxHealth;
        public int currentHealth;
        public float speed;
        public int startWeapon;
        public ChoosenEmu(int emuId2, string emuName2, int maxHealth2, int currentHealth2, float speed2, int startWeapon2)
        {
            emuId = emuId2;
            emuName = emuName2;
            maxHealth = maxHealth2;
            currentHealth = currentHealth2;
            speed = speed2;
            startWeapon = startWeapon2;
            
        }
        
    }

    private void Start()
    {

        ChoosenEmu baseEmu = new ChoosenEmu(0, "Bob kangaroo the emu", 250,240,4f,0);
        ChoosenEmu alienEmu = new (1, "Paul the alien emu", 200, 200, 4f, 1);
        ChoosenEmu ritterEmu = new (2, "Ezekiel the knight emu", 300, 300, 3.75f, 2);
        ChoosenEmu roadRunnerEmu = new (3, "Frederik the roadrunner emu", 250, 250, 4.5f, 3);        
        ChoosenEmu pharaoEmu = new (4, "Joshua VII the pharao emu", 300, 300, 4, 4);
        emus[0] = baseEmu;
        emus[1] = alienEmu;
        emus[2] = ritterEmu;
        emus[3] = roadRunnerEmu;
        emus[4] = pharaoEmu;
                    
    }

}

