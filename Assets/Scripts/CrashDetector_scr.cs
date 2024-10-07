using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector_scr : MonoBehaviour
{
    [SerializeField] float resetDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSfx;
    private bool notDead = true;
    void OnTriggerEnter2D(Collider2D crash)//if top's collider hits something NOT the finish
    {
        if(crash.tag != "Finish" && notDead)
        {
            notDead = false;
            FindObjectOfType<PlayerControl_scr>().DisableControls();
            crashEffect.Play();
            Invoke("ReloadScene", resetDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
        }
    }
    void ReloadScene()
    {
        FindObjectOfType<PlayerControl_scr>().ResetVar();
        SceneManager.LoadScene(0);
    }
}
