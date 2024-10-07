using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector_scr : MonoBehaviour
{
    [SerializeField] float resetDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSfx;
    void OnTriggerEnter2D(Collider2D crash)//if top's collider hits something NOT the finish
    {
        if(crash.tag != "Finish")
        {
            FindObjectOfType<PlayerControl_scr>().DisableControls();
            crashEffect.Play();
            Invoke("ReloadScene", resetDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
