using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLOWMOTION : MonoBehaviour
{
    public float SlowMotion;
    public static bool HeldDown = false;
    
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
            }
            else
            {
                SlowDown();
            }
            
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
