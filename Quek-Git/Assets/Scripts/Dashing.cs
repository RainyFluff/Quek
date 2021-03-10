using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dashing : MonoBehaviour
{
    public Rigidbody rb;
    public float Strength;
    public float Wait;
    public GameObject Orientation;
    bool ReadyToDash = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ReadyToDash = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ReadyToDash = true;
            
        }
        else
        {
            ReadyToDash = false;
            StartMovement();
        }
    }

    void DisableMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

    void StartMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
    }
    void FixedUpdate()
    {
       
        if (ReadyToDash == true)
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Orientation.transform.forward * Strength, ForceMode.Impulse);
            DisableMovement();
        }

    }


}
