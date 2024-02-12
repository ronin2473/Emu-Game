using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTraversing : MonoBehaviour
{
    [System.Serializable]
    public class Buttonv2
    {
        public int x;
        public int y;
        public Button button;
        public  Buttonv2 (int cordx,int cordy,Button thebutton) 
        {
            this.x = cordx;
            this.y = cordy;
            this.button = thebutton;
        }
    }
    public Button selectedbutton;
    public List<Buttonv2> buttons;
    public int xmax;
    public int ymax;
    public int x;
    public  int y;

    // Update is called once per frame
    void Update()
    {
        string[] joystickNames = Input.GetJoystickNames();
        Debug.Log(joystickNames.Length);
        
        if (Input.GetAxis("Vertical") != 0 && joystickNames.Length > 0)
        {
            y += ((int)Mathf.Sign(Input.GetAxis("Vertical")));
            if (y > ymax)
            {
                y = 0;
            }
            else if (y < 0)
            {
                y = ymax;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("test");
            y += 1;
            if (y > ymax)
            {
                y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            y -= 1;
            if (y < 0)
            {
                y = ymax;
            }
        }

        if (Input.GetAxis("Horizontal") != 0 && joystickNames.Length > 0)
        {
            x += ((int)Mathf.Sign(Input.GetAxis("Horizontal")));
            if (x > xmax)
            {
                x = 0;
            }
             else if (x < 0)
            {
                x = xmax;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x += 1;
            if (x > xmax)
            {
                x = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            x -= 1;
            if (x < 0)
            {
                x = xmax;
            }
        }
        foreach (Buttonv2 button in buttons)
        {
            if (button.x == x &&  button.y == y) {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                foreach (Buttonv2 v in buttons)
                {
                    
                    v.button.OnPointerExit(pointerEventData);
                        }
                selectedbutton = button.button;
                
                button.button.OnPointerEnter(pointerEventData);
                break;
            }
        }
        
        if (Input.GetButtonDown("Submit"))
        {
            selectedbutton.onClick.Invoke();
        }

    }
}
