using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEqualsSlider : MonoBehaviour
{
    public float maxHeight;
    public float height;
    public float step;
    public RectTransform heart;
    public RectTransform arrow;
    // Start is called before the first frame update

    private void Start()
    {
        heart.sizeDelta = new Vector2(heart.sizeDelta.x,0);
        arrow.sizeDelta = new Vector2(heart.sizeDelta.x, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (height < maxHeight) {
            height += step;
            heart.sizeDelta += new Vector2(0,step);
            arrow.sizeDelta += new Vector2(0, step);
        }

        if (height >= maxHeight) {
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate ()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        StopCoroutine(Deactivate());
    }
}
