using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_scr : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqAmount = 5f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 10f;
    SurfaceEffector2D surfaceEffector2d;
    private bool disable = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
    }
    void Update()
    {
        if(!disable)
        {
            RotatePlayer();
            GetBoost();
            SlowDown();
        }
    }
    public void DisableControls()
    {
        disable = true;
    }

    void GetBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2d.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2d.speed = baseSpeed;
        }
    }
    void SlowDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            surfaceEffector2d.speed = slowSpeed;
        }
        else
        {
            surfaceEffector2d.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqAmount);
        }
    }
}
