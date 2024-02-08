using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGlow : MonoBehaviour
{
    public Transform uiElement;
    public Material mat;
    public Camera cam;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = cam.ScreenToWorldPoint(uiElement.position);
        mat.SetVector("_CharacterPosition", worldPosition);
    }
}
