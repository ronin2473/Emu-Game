using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public static float time = 0;
    public float speed = 3f;
    private Rigidbody2D rb2d;
    int charid = CharController.choosenChar;
    public TextMeshProUGUI timer;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public Collider2D edgemap;  
    Gamemenu gamemenu;

    // Start is called before the first frame update
    void Start()
    {
        gamemenu = FindObjectOfType<Gamemenu>();
        rb2d = GetComponent<Rigidbody2D>();
        Emu.ChoosenEmu emu = Emu.emus[charid];
        if (emu != null)
        {
            speed = emu.speed;
        }
        time = 0;

        AudioManager audi = FindObjectOfType<AudioManager>();
        audi.PlayMusic("BattleMusic");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text = time.ToString();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isdead = GetComponent<Health>().isdead;
        if (moveHorizontal < 0 && isdead == false) this.transform.localScale = new Vector3(-1, 1, 1);
        if (moveHorizontal > 0 && isdead == false) this.transform.localScale = new Vector3(1, 1, 1);
        //float velocity = Mathf.Abs(rb2d.velocity.x);
        //float factor = Mathf.Clamp01(velocity / speed);
        //float invertFactorx = 1f - factor;
        //float invertFactory = 1f - factor;
        //if (moveHorizontal * rb2d.velocity.x < 0f) invertFactorx = 1f;
        //if (moveVertical * rb2d.velocity.y < 0f) invertFactory = 1f;
        rb2d.velocity = new Vector2(moveHorizontal * speed   , moveVertical * speed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamemenu.Menu();
        }
    }
}
