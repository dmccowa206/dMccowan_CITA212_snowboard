using UnityEngine;

public class BoulderTrail_scr : MonoBehaviour
{
    [SerializeField] ParticleSystem boulderEffect;
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            boulderEffect.Play();
        }
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            boulderEffect.Stop();
        }
    }
}
