using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinshLine_scr : MonoBehaviour
{
    [SerializeField] float resetDelay = 3f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Ya");
        if(trigger.tag == "Player")
        {
            finishEffect.Play();
            Invoke("ReloadScene", resetDelay);
            GetComponent<AudioSource>().Play();
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
