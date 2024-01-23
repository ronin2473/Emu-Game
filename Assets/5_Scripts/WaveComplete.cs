using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveComplete : MonoBehaviour
{
    public TextMeshProUGUI text;
    Color color1;
    Color color2;
    Color color3;
    Color color4;
    public float time = 0;
    public float timetowait = 3f;
    public float lifetime;
    bool played = false;
    public List<AudioSource> wavecompletesounds;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        if (time > timetowait)
        {
            RandomColor();
            time = 0;   
        }
            time += Time.deltaTime;
        
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
        StopCoroutine("DisableObject");
    }

    private void OnEnable()
    {
        int x = Random.Range(0,wavecompletesounds.Count);
        if (played)
        {
            wavecompletesounds[x].Play();
        }
        played = true ;
        StartCoroutine("DisableObject");

    }
    public void RandomColor()
    {
        color1 = new Color(Random.value, Random.value, Random.value);
        color2 = new Color(Random.value, Random.value, Random.value);
        color3 = new Color(Random.value, Random.value, Random.value);
        color4 = new Color(Random.value, Random.value, Random.value);
        VertexGradient vertexGradient = new VertexGradient(color1, color2, color3, color4);
        text.colorGradient = vertexGradient;
    }
}
