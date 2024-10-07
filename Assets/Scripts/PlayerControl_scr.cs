using TMPro;
using UnityEngine;

public class PlayerControl_scr : MonoBehaviour
{
    Rigidbody2D rb2d;
    public TextMeshProUGUI scoreText;
    [SerializeField] float torqAmount = 5f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 10f;
    public int score = 0;
    SurfaceEffector2D surfaceEffector2d;
    private bool disable = false;
    private bool upsideDown = false;
    public bool airborne = false;
    float angleCheck;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
        scoreText.text = score.ToString();
        angleCheck = 0f;
    }
    void Update()
    {
        if(!disable)
        {
            RotatePlayer();
            ChangeSpeed();
            Scorable();
        }
    }
    public void DisableControls()
    {
        disable = true;
    }

    void ChangeSpeed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2d.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
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
    void Scorable()
    {
        angleCheck = Mathf.Abs(Mathf.DeltaAngle(Mathf.Abs(gameObject.transform.rotation.eulerAngles.z), 0));
        if (!upsideDown)
        {
            if (angleCheck > 170)
            {
                upsideDown = true;
            }
        }
        else if (upsideDown)
        {
            if (angleCheck < 10)
            {
                upsideDown = false;
                score += 1000;
                scoreText.text = score.ToString();
            } 
        }
        if (airborne)
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
    void OnCollisionEnter2D(Collision2D g)
    {
        if (g.gameObject.tag == "Ground")
        {
            airborne = false;
        }
    }
    void OnCollisionExit2D(Collision2D g)
    {
        if (g.gameObject.tag == "Ground")
        {
            airborne = true;
        }
    }
    public void ResetVar()
    {
        score = 0;
        scoreText.text = score.ToString();
        airborne = false;
        angleCheck = 0f;
    }
}
