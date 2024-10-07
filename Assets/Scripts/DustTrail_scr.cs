using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail_scr : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            dustEffect.Play();
        }
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            dustEffect.Stop();
        }
    }
}
