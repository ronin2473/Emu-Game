using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUi : MonoBehaviour
{
    public Sprite[] itemSprites;
    public List<Sprite> activeItems;
    public List<Image> itemSlots = new List<Image>();
    public int offset = 100;
    public Image itemslot;
    void Start()
    {

        itemSlots.Add(itemslot);
        int charid = CharController.choosenChar;
        //activeItems.Add(itemSprites[charid]);
        
    }

    private void Update()
    {
        ResyncItems();
    }


    public void ResyncItems()
    {
        
        int i = 0;
        foreach (Sprite sprite in activeItems)
        {
            //Debug.Log("i = " + i);
            //Debug.Log("len = " + (itemSlots.Count ));
            if (i < itemSlots.Count  )
            {
                itemSlots[i].sprite = sprite;
            }
            else
            {
                Image tmp = Instantiate(itemSlots[0],this.transform);
                tmp.transform.localPosition = new Vector3 (tmp.transform.localPosition.x + offset * i, tmp.transform.localPosition.y, tmp.transform.localPosition.z);
                itemSlots.Add(tmp);
            }
            i++;    
        }
    }
    

}
