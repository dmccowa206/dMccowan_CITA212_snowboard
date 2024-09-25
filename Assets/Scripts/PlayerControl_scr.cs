using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_scr : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqAmount = 3;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqAmount);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqAmount);
        }
    }
}
