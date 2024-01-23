//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class HasItems : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public int id;
        public Sprite sprite;
        public GameObject gameObject;
        public WeaponManagement.weapon weapon;
        public Item (int id, Sprite sprite, GameObject gameObject)
        {
            this.id = id;
            this.sprite = sprite;
            this.gameObject = gameObject;
        }
    }
    
    public List<Item> items = new List<Item>();
    public List<Item> allitems = new List<Item>();
    [SerializeField] ItemsUi itemsprites;
    [SerializeField] WeaponManagement weapon;
    public void AddItem(int id, Sprite sprite, GameObject gameobject, WeaponManagement.weapon weapon)
    {
        if (weapon != null)
        {
            weapon.level += 1;
            weapon.isActive = true;
            //level up weapon
        }
        if (id > items.Count -1)
        {
            Item tmp = new Item(id, sprite, gameobject);
            tmp.weapon = weapon;
            this.items.Add(tmp);
        }
        itemsprites.activeItems.Add(itemsprites.itemSprites[id]);


    }
    // Start is called before the first frame update
    void Start()
    {
        int charid = CharController.choosenChar;
        AddItem(charid, itemsprites.itemSprites[charid], weapon.weapons[charid].thisWeapon, weapon.weapons[charid]);
        foreach (WeaponManagement.weapon weapon2 in weapon.weapons)
        {
            Item tmp2 = new Item(weapon2.WeaponId, itemsprites.itemSprites[weapon2.WeaponId], weapon2.thisWeapon);
            tmp2.weapon = weapon2;
            allitems.Add(tmp2);
        }

        //itemsprites.activeItems.Add(itemsprites.itemSprites[charid]);
    }
    // Update is called once per frame
    
    public void LevelUp()
    {
        int x = (int)UnityEngine.Random.Range(0, allitems.Count);
        if (allitems[x].weapon.level < 3)
        {
            AddItem(allitems[x].id, allitems[x].sprite, allitems[x].gameObject, allitems[x].weapon);
        }
        else
        {
            LevelUp();
        }
    }
}
