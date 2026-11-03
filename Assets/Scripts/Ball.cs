
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private SpriteRenderer ballspr;
    [SerializeField] private float bounceSpeed;
    [SerializeField] private Color[] colors;
    [SerializeField] private GameManager gameManage;


    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballspr = GetComponent<SpriteRenderer>();
        RandomColor();
        
    }
    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            ballRb.linearVelocityY = 0f;
            ballRb.AddForce(Vector2.up * bounceSpeed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("colorchanger"))
        {
            int rnd = Random.Range(0, 4);
            ballspr.color = colors[rnd];
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("edges") && collision.GetComponent<EdgesColor>().color != ballspr.color || collision.CompareTag("OutCam"))
        {
            gameManage.Retry();
        }
        else if (collision.CompareTag("star"))
        {
            gameManage.AddScore();
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Finish"))
        {
            gameManage.NextLevel();
        }
        
    }
    private void RandomColor()
    {
        int randomStartColor = Random.Range(0, 4);
        ballspr.color = colors[randomStartColor];
    }
}
