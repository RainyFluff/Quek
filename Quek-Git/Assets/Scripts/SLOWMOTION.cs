using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLOWMOTION : MonoBehaviour
{
    public float SlowMotion;
    public static bool HeldDown = false;
    public GameObject PP;
    public GameObject PostProcessing;
    public AudioSource Music;
    public float Volume;
    public float MusicSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = Time.timeScale * .02f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (HeldDown)
            {
                Normal();
                PP.SetActive(false);
                PostProcessing.SetActive(true);
                Music.pitch = MusicSpeed;
                Music.volume = Volume;
            }
            else
            {
                SlowDown();
                PP.SetActive(true);
                PostProcessing.SetActive(false);
                Music.pitch = Time.timeScale * MusicSpeed * 2;
                Music.volume = Volume / 2;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse3))
        {


        }
    }   

    void SlowDown()
    {
        Time.timeScale = SlowMotion;
        HeldDown = true;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        
    }

    void Normal()
    {
        Time.timeScale = 1f;
        HeldDown = false;
        Time.fixedDeltaTime = .02f;
    }

}
